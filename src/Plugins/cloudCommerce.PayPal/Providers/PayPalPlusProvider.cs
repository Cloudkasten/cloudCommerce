using System;
using cloudCommerce.Core.Plugins;
using cloudCommerce.PayPal.Controllers;
using cloudCommerce.PayPal.Settings;
using cloudCommerce.Services.Payments;

namespace cloudCommerce.PayPal
{
	[SystemName("Payments.PayPalPlus")]
    [FriendlyName("PayPal PLUS")]
    [DisplayOrder(1)]
    public partial class PayPalPlusProvider : PayPalRestApiProviderBase<PayPalPlusPaymentSettings>
    {
		public static string SystemName
		{
			get { return "Payments.PayPalPlus"; }
		}

		public override PaymentMethodType PaymentMethodType
		{
			get
			{
				return PaymentMethodType.StandardAndRedirection;
			}
		}

		public override Type GetControllerType()
		{
			return typeof(PayPalPlusController);
		}
	}
}