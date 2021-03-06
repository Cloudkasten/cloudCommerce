using cloudCommerce.Core;
using cloudCommerce.Web.Framework;
using cloudCommerce.Web.Framework.Plugins;

namespace cloudCommerce.Admin.Models.Payments
{
	public class PaymentMethodModel : ProviderModel, IActivatable
    {
        public bool IsActive { get; set; }

        [SmartResourceDisplayName("Admin.Configuration.Payment.Methods.Fields.SupportCapture")]
        public bool SupportCapture { get; set; }

        [SmartResourceDisplayName("Admin.Configuration.Payment.Methods.Fields.SupportPartiallyRefund")]
        public bool SupportPartiallyRefund { get; set; }

        [SmartResourceDisplayName("Admin.Configuration.Payment.Methods.Fields.SupportRefund")]
        public bool SupportRefund { get; set; }

        [SmartResourceDisplayName("Admin.Configuration.Payment.Methods.Fields.SupportVoid")]
        public bool SupportVoid { get; set; }

        [SmartResourceDisplayName("Admin.Configuration.Payment.Methods.Fields.RecurringPaymentType")]
        public string RecurringPaymentType { get; set; }
    }
}