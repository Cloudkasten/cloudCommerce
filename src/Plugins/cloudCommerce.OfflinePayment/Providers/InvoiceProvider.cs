using cloudCommerce.Core.Plugins;
using cloudCommerce.OfflinePayment.Settings;

namespace cloudCommerce.OfflinePayment
{
	[SystemName("Payments.Invoice")]
	[FriendlyName("Invoice")]
	[DisplayOrder(1)]
	public class InvoiceProvider : OfflinePaymentProviderBase<InvoicePaymentSettings>, IConfigurable
	{
		protected override string GetActionPrefix()
		{
			return "Invoice";
		}
	}
}