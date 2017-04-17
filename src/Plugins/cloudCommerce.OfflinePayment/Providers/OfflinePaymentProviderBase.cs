using System;
using System.Collections.Generic;
using System.Web.Routing;
using cloudCommerce.Core.Configuration;
using cloudCommerce.Core.Domain.Orders;
using cloudCommerce.Core.Domain.Payments;
using cloudCommerce.OfflinePayment.Controllers;
using cloudCommerce.OfflinePayment.Settings;
using cloudCommerce.Services;
using cloudCommerce.Services.Orders;
using cloudCommerce.Services.Payments;

namespace cloudCommerce.OfflinePayment
{
	public abstract class OfflinePaymentProviderBase<TSetting> : PaymentMethodBase
		where TSetting : PaymentSettingsBase, ISettings, new()
    {
		public ICommonServices CommonServices { get; set; }
		public IOrderTotalCalculationService OrderTotalCalculationService { get; set; }

		public override Type GetControllerType()
		{
			return typeof(OfflinePaymentController);
		}

		public override PaymentMethodType PaymentMethodType
		{
			get
			{
				return PaymentMethodType.Standard;
			}
		}

		protected abstract string GetActionPrefix();

		public override decimal GetAdditionalHandlingFee(IList<OrganizedShoppingCartItem> cart)
		{
			var result = decimal.Zero;
			try
			{
				var settings = CommonServices.Settings.LoadSetting<TSetting>(CommonServices.StoreContext.CurrentStore.Id);

				result = this.CalculateAdditionalFee(OrderTotalCalculationService, cart, settings.AdditionalFee, settings.AdditionalFeePercentage);
			}
			catch (Exception)
			{
			}
			return result;
		}

		public override void GetConfigurationRoute(out string actionName, out string controllerName, out RouteValueDictionary routeValues)
		{
			actionName = "{0}Configure".FormatInvariant(GetActionPrefix());
			controllerName = "OfflinePayment";
			routeValues = new RouteValueDictionary() { { "area", "cloudCommerce.OfflinePayment" } };
		}

		public override void GetPaymentInfoRoute(out string actionName, out string controllerName, out RouteValueDictionary routeValues)
		{
			actionName = "{0}PaymentInfo".FormatInvariant(GetActionPrefix());
			controllerName = "OfflinePayment";
			routeValues = new RouteValueDictionary() { { "area", "cloudCommerce.OfflinePayment" } };
		}

		public override ProcessPaymentResult ProcessPayment(ProcessPaymentRequest processPaymentRequest)
		{
			var result = new ProcessPaymentResult();
			result.NewPaymentStatus = PaymentStatus.Pending;
			return result;
		}
	}
}