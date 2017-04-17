using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using cloudCommerce.Utilities;
using cloudCommerce.Utilities.Threading;
using cloudCommerce.Core.Logging;
using Log = cloudCommerce.Core.Logging;
using NuGet;
using NuGetPackageManager = NuGet.PackageManager;
using cloudCommerce.Core.Data;
using cloudCommerce.Core.Plugins;

namespace cloudCommerce.Core.Packaging
{
	
	public sealed class AppUpdater : DisposableObject
	{
		public const string UpdatePackagePath = "~/App_Data/Update";
		
		private static readonly ReaderWriterLockSlim _rwLock = new ReaderWriterLockSlim();
		private TraceLogger _logger;

		#region Package update

		[SuppressMessage("ReSharper", "RedundantAssignment")]
		public bool InstallablePackageExists()
		{
			string packagePath = null;
			var package = FindPackage(false, out packagePath);

			if (package == null)
				return false;

			if (!ValidatePackage(package))
				return false;

			if (!CheckEnvironment())
				return false;

			return true;
		}

		internal bool TryUpdateFromPackage()
		{
			// NEVER EVER (!!!) make an attempt to auto-update in a dev environment!!!!!!!
			if (CommonHelper.IsDevEnvironment)
				return false;
			
			using (_rwLock.GetUpgradeableReadLock())
			{
				try
				{
					string packagePath = null;
					var package = FindPackage(true, out packagePath);

					if (package == null)
						return false;

					if (!ValidatePackage(package))
						return false;

					if (!CheckEnvironment())
						return false;

					using (_rwLock.GetWriteLock())
					{
						Backup();

						var info = ExecuteUpdate(package);

						if (info != null)
						{
							var newPath = packagePath + ".applied";
							if (File.Exists(newPath))
							{
								File.Delete(packagePath);
							}
							else
							{
								File.Move(packagePath, newPath);
							}						
						}

						return info != null;
					}
				}
				catch (Exception ex)
				{
					_logger.Error("An error occured while updating the application: {0}".FormatCurrent(ex.Message), ex);
					return false;
				}
			}
		}

		private TraceLogger CreateLogger(IPackage package)
		{
			var logFile = Path.Combine(CommonHelper.MapPath(UpdatePackagePath, false), "Updater.{0}.log".FormatInvariant(package.Version.ToString()));
			return new TraceLogger(logFile);
		}

		private IPackage FindPackage(bool createLogger, out string path)
		{
			path = null;
			var dir = CommonHelper.MapPath(UpdatePackagePath, false);

			if (!Directory.Exists(dir))
				return null;

			var files = Directory.GetFiles(dir, "cloudCommerce.*.nupkg", SearchOption.TopDirectoryOnly);

			// TODO: allow more than one package in folder and return newest
			if (files.Length == 0 || files.Length > 1)
				return null;

			try
			{
				path = files[0];
				IPackage package = new ZipPackage(files[0]);
				if (createLogger)
				{
					_logger = CreateLogger(package);
					_logger.Information("Found update package '{0}'".FormatInvariant(package.GetFullName()));
				}
				return package;
			}
			catch { }

			return null;
		}

		private bool ValidatePackage(IPackage package)
		{
			if (package.Id != "cloudCommerce")
				return false;
			
			var currentVersion = new SemanticVersion(cloudCommerceVersion.Version);
			return package.Version > currentVersion;
		}

		private bool CheckEnvironment()
		{
			// TODO: Check it :-)
			return true;
		}

		private void Backup()
		{
			var source = new DirectoryInfo(CommonHelper.MapPath("~/"));

			var tempPath = CommonHelper.MapPath("~/App_Data/_Backup/App/cloudCommerce");
			string localTempPath = null;
			for (int i = 0; i < 50; i++)
			{
				localTempPath = tempPath + (i == 0 ? "" : "." + i.ToString());
				if (!Directory.Exists(localTempPath))
				{
					Directory.CreateDirectory(localTempPath);
					break;
				}
				localTempPath = null;
			}
			
			if (localTempPath == null)
			{
				var exception = new SmartException("Too many backups in '{0}'.".FormatInvariant(tempPath));
				_logger.Error(exception.Message, exception);
				throw exception;
			}

			var backupFolder = new DirectoryInfo(localTempPath);
			var folderUpdater = new FolderUpdater(_logger);
			folderUpdater.Backup(source, backupFolder, "App_Data", "Media");

			_logger.Information("Backup successfully created in folder '{0}'.".FormatInvariant(localTempPath));
		}

		private PackageInfo ExecuteUpdate(IPackage package)
		{
			var appPath = CommonHelper.MapPath("~/");
			
			var logger = new NugetLogger(_logger);

			var project = new FileBasedProjectSystem(appPath) { Logger = logger };

			var nullRepository = new NullSourceRepository();

			var projectManager = new ProjectManager(
				nullRepository,
				new DefaultPackagePathResolver(appPath),
				project,
				nullRepository
				) { Logger = logger };

			// Perform the update
			projectManager.AddPackageReference(package, true, false);

			var info = new PackageInfo
			{
				Id = package.Id,
				Name = package.Title ?? package.Id,
				Version = package.Version.ToString(),
				Type = "App",
				Path = appPath
			};

			_logger.Information("Update '{0}' successfully executed.".FormatInvariant(info.Name));

			return info;
		}

		#endregion


		#region Migrations

		internal void ExecuteMigrations()
		{
			if (!DataSettings.DatabaseIsInstalled())
				return;

			var currentVersion = cloudCommerceVersion.Version;
			var prevVersion = DataSettings.Current.AppVersion ?? new Version(1, 0);

			if (prevVersion >= currentVersion)
				return;

			if (prevVersion < new Version(2, 1))
			{
				// we introduced app migrations in V2.1. So any version prior 2.1
				// has to perform the initial migration
				MigrateInitial();
			}

			DataSettings.Current.AppVersion = currentVersion;
			DataSettings.Current.Save();
		}

		private void MigrateInitial()
		{
			var installedPlugins = PluginFileParser.ParseInstalledPluginsFile();
			if (installedPlugins.Count == 0)
				return;

			var renamedPlugins = new List<string>();
			
			var pluginRenameMap = new Dictionary<string, string>
			{
				{ "CurrencyExchange.ECB", null /* null means: remove it */ },	
				{ "CurrencyExchange.MoneyConverter", null },
				{ "ExternalAuth.OpenId", null },
				{ "Tax.Free", null },
				{ "Api.WebApi", "cloudCommerce.WebApi" },	
				{ "DiscountRequirement.MustBeAssignedToCustomerRole", "cloudCommerce.DiscountRules" },
				{ "DiscountRequirement.HadSpentAmount", "cloudCommerce.DiscountRules" },	
				{ "DiscountRequirement.HasAllProducts", "cloudCommerce.DiscountRules" },	
				{ "DiscountRequirement.HasOneProduct", "cloudCommerce.DiscountRules" },	
				{ "DiscountRequirement.Store", "cloudCommerce.DiscountRules" },	
				{ "DiscountRequirement.BillingCountryIs", "cloudCommerce.DiscountRules" },	
				{ "DiscountRequirement.ShippingCountryIs", "cloudCommerce.DiscountRules" },	
				{ "DiscountRequirement.HasPaymentMethod", "cloudCommerce.DiscountRules.HasPaymentMethod" },	
				{ "DiscountRequirement.HasShippingOption", "cloudCommerce.DiscountRules.HasShippingOption" },	
				{ "DiscountRequirement.PurchasedAllProducts", "cloudCommerce.DiscountRules.PurchasedProducts" },
				{ "DiscountRequirement.PurchasedOneProduct", "cloudCommerce.DiscountRules.PurchasedProducts" },
				{ "PromotionFeed.Froogle", "cloudCommerce.GoogleMerchantCenter" },
				{ "PromotionFeed.Billiger", "cloudCommerce.Billiger" },
				{ "PromotionFeed.ElmarShopinfo", "cloudCommerce.ElmarShopinfo" },
				{ "PromotionFeed.Guenstiger", "cloudCommerce.Guenstiger" },
				{ "Payments.AccardaKar", "cloudCommerce.AccardaKar" },
				{ "Payments.AmazonPay", "cloudCommerce.AmazonPay" },
				{ "Developer.DevTools", "cloudCommerce.DevTools" },
				{ "ExternalAuth.Facebook", "cloudCommerce.FacebookAuth" },
				{ "ExternalAuth.Twitter", "cloudCommerce.TwitterAuth" },
				{ "SMS.Clickatell", "cloudCommerce.Clickatell" },
				{ "Widgets.GoogleAnalytics", "cloudCommerce.GoogleAnalytics" },
				{ "Misc.DemoShop", "cloudCommerce.DemoShopControlling" },
				{ "Admin.OrderNumberFormatter", "cloudCommerce.OrderNumberFormatter" },
				{ "Admin.Debitoor", "cloudCommerce.Debitoor" },
                { "Widgets.ETracker", "cloudCommerce.ETracker" },
                { "Payments.PayPalDirect", "cloudCommerce.PayPal" },
                { "Payments.PayPalStandard", "cloudCommerce.PayPal" },
                { "Payments.PayPalExpress", "cloudCommerce.PayPal" },
				{ "Developer.Glimpse", "cloudCommerce.Glimpse" },
				{ "Import.Biz", "cloudCommerce.BizImporter" },
				{ "Payments.Sofortueberweisung", "cloudCommerce.Sofortueberweisung" },
				{ "Payments.PostFinanceECommerce", "cloudCommerce.PostFinanceECommerce" },
				{ "Misc.MailChimp", "cloudCommerce.MailChimp" },
				{ "Mobile.SMS.Verizon", "cloudCommerce.Verizon" },
				{ "Widgets.LivePersonChat", "cloudCommerce.LivePersonChat" },
				{ "Payments.CashOnDelivery", "cloudCommerce.OfflinePayment" },
				{ "Payments.Invoice", "cloudCommerce.OfflinePayment" },
				{ "Payments.PayInStore", "cloudCommerce.OfflinePayment" },
				{ "Payments.Prepayment", "cloudCommerce.OfflinePayment" },
                { "Payments.IPaymentCreditCard", "cloudCommerce.IPayment" },
                { "Payments.IPaymentDirectDebit", "cloudCommerce.IPayment" },
                { "Payments.AuthorizeNet", "cloudCommerce.AuthorizeNet" },
                { "Shipping.AustraliaPost", "cloudCommerce.AustraliaPost" },
                { "Shipping.CanadaPost", "cloudCommerce.CanadaPost" },
                { "Shipping.Fedex", "cloudCommerce.Fedex" },
                { "Shipping.UPS", "cloudCommerce.UPS" },
				{ "Payments.Manual", "cloudCommerce.OfflinePayment" },
                { "Shipping.USPS", "cloudCommerce.USPS" },
                { "Widgets.TrustedShopsSeal", "cloudCommerce.TrustedShops" },
                { "Widgets.TrustedShopsCustomerReviews", "cloudCommerce.TrustedShops" },
                { "Widgets.TrustedShopsCustomerProtection", "cloudCommerce.TrustedShops" },
                { "Shipping.ByWeight", "cloudCommerce.ShippingByWeight" },
				{ "Payments.DirectDebit", "cloudCommerce.OfflinePayment" },
				{ "Tax.FixedRate", "cloudCommerce.Tax" },
				{ "Tax.CountryStateZip", "cloudCommerce.Tax" },
                { "Shipping.ByTotal", "cloudCommerce.Shipping" },
                { "Shipping.FixedRate", "cloudCommerce.Shipping" }
			};

			foreach (var name in installedPlugins)
			{
				if (pluginRenameMap.ContainsKey(name))
				{
					string newName = pluginRenameMap[name];
					if (newName != null && !renamedPlugins.Contains(newName))
					{
						renamedPlugins.Add(newName);
					}
				}
				else
				{
					renamedPlugins.Add(name);
				}
			}

			PluginFileParser.SaveInstalledPluginsFile(renamedPlugins);
		}

		#endregion


		protected override void OnDispose(bool disposing)
		{
			if (disposing)
			{
				if (_logger != null)
				{
					_logger.Dispose();
					_logger = null;
				}
			}
		}
	}

}
