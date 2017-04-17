using cloudCommerce.Core.Plugins;
using cloudCommerce.OfflinePayment.Settings;

namespace cloudCommerce.OfflinePayment
{
	[SystemName("Payments.CashOnDelivery")]
	[FriendlyName("Cash On Delivery (COD)")]
	[DisplayOrder(1)]
	public class CashOnDeliveryPaymentProcessor : OfflinePaymentProviderBase<CashOnDeliveryPaymentSettings>, IConfigurable
	{
		protected override string GetActionPrefix()
		{
			return "CashOnDelivery";
		}
	}
}