using System.Web.Routing;
using cloudCommerce.Core.Plugins;
using cloudCommerce.Services.Configuration;
using cloudCommerce.Services.Localization;
using cloudCommerce.Services.Security;
using cloudCommerce.Web.Framework.WebApi;
using cloudCommerce.Web.Framework.WebApi.Caching;
using cloudCommerce.WebApi.Security;

namespace cloudCommerce.WebApi
{
	public class WebApiPlugin : BasePlugin, IConfigurable
	{
		private readonly IPermissionService _permissionService;
		private readonly ILocalizationService _localizationService;
		private readonly ISettingService _settingService;

		public WebApiPlugin(IPermissionService permissionService, ILocalizationService localizationService, ISettingService settingService)
		{
			_permissionService = permissionService;
			_localizationService = localizationService;
			_settingService = settingService;
		}


		public void GetConfigurationRoute(out string actionName, out string controllerName, out RouteValueDictionary routeValues)
		{
			actionName = "Configure";
			controllerName = "WebApi";
			routeValues = new RouteValueDictionary() { { "Namespaces", "cloudCommerce.WebApi.Controllers" }, { "area", WebApiGlobal.PluginSystemName } };
		}

		public override void Install()
		{
			_permissionService.InstallPermissions(new WebApiPermissionProvider());

			var apiSettings = new WebApiSettings
			{
				LogUnauthorized = true,
				ValidMinutePeriod = WebApiGlobal.DefaultTimePeriodMinutes
			};

			_settingService.SaveSetting<WebApiSettings>(apiSettings);

			_localizationService.ImportPluginResourcesFromXml(this.PluginDescriptor);

			base.Install();

			WebApiCachingControllingData.Remove();
			WebApiCachingUserData.Remove();
		}

		public override void Uninstall()
		{
			WebApiCachingControllingData.Remove();
			WebApiCachingUserData.Remove();

			_settingService.DeleteSetting<WebApiSettings>();

			_permissionService.UninstallPermissions(new WebApiPermissionProvider());

			base.Uninstall();
		}

	}
}
