using System.Collections.Generic;
using System.Web.Mvc;
using cloudCommerce.AmazonPay.Models;
using cloudCommerce.AmazonPay.Services;
using cloudCommerce.AmazonPay.Settings;
using cloudCommerce.Services;
using cloudCommerce.Services.Payments;
using cloudCommerce.Services.Stores;
using cloudCommerce.Web.Framework.Controllers;
using cloudCommerce.Web.Framework.Security;
using cloudCommerce.Web.Framework.Settings;

namespace cloudCommerce.AmazonPay.Controllers
{
	public class AmazonPayController : PaymentControllerBase
	{
		private readonly IAmazonPayService _apiService;
		private readonly ICommonServices _services;
		private readonly IStoreService _storeService;

		public AmazonPayController(
			IAmazonPayService apiService,
			ICommonServices services,
			IStoreService storeService)
		{
			_apiService = apiService;
			_services = services;
			_storeService = storeService;
		}

		[NonAction]
		public override IList<string> ValidatePaymentForm(FormCollection form)
		{
			var warnings = new List<string>();
			return warnings;
		}

		[NonAction]
		public override ProcessPaymentRequest GetPaymentInfo(FormCollection form)
		{
			var paymentInfo = new ProcessPaymentRequest();
			return paymentInfo;
		}

		[AdminAuthorize]
		public ActionResult Configure()
		{
			var model = new ConfigurationModel();
			int storeScope = this.GetActiveStoreScopeConfiguration(_storeService, _services.WorkContext);
			var settings = _services.Settings.LoadSetting<AmazonPaySettings>(storeScope);

			model.Copy(settings, true);

			_apiService.SetupConfiguration(model);

			var storeDependingSettingHelper = new StoreDependingSettingHelper(ViewData);
			storeDependingSettingHelper.GetOverrideKeys(settings, model, storeScope, _services.Settings);

			return View(model);
		}

		[HttpPost, AdminAuthorize]
		public ActionResult Configure(ConfigurationModel model, FormCollection form)
		{
			if (!ModelState.IsValid)
				return Configure();

			ModelState.Clear();

			var storeDependingSettingHelper = new StoreDependingSettingHelper(ViewData);
			int storeScope = this.GetActiveStoreScopeConfiguration(_storeService, _services.WorkContext);
			var settings = _services.Settings.LoadSetting<AmazonPaySettings>(storeScope);

			model.Copy(settings, false);

			storeDependingSettingHelper.UpdateSettings(settings, form, storeScope, _services.Settings);

			_services.Settings.SaveSetting(settings, x => x.DataFetching, 0, false);
			_services.Settings.SaveSetting(settings, x => x.PollingMaxOrderCreationDays, 0, false);

			_apiService.DataPollingTaskUpdate(settings.DataFetching == AmazonPayDataFetchingType.Polling, model.PollingTaskMinutes * 60);

			_services.Settings.ClearCache();
			NotifySuccess(_services.Localization.GetResource("Plugins.Payments.AmazonPay.ConfigSaveNote"));

			return Configure();
		}

		[HttpPost]
		[ValidateInput(false)]
		[RequireHttpsByConfigAttribute(SslRequirement.Yes)]
		public ActionResult IPNHandler()
		{
			_apiService.ProcessIpn(Request);
			return Content("OK");
		}
	}
}
