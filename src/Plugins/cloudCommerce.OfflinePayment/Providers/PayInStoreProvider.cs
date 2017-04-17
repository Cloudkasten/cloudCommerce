using cloudCommerce.Core.Plugins;
using cloudCommerce.OfflinePayment.Settings;

namespace cloudCommerce.OfflinePayment
{
	[SystemName("Payments.PayInStore")]
	[FriendlyName("Pay In Store")]
	[DisplayOrder(1)]
	public class PayInStoreProvider : OfflinePaymentProviderBase<PayInStorePaymentSettings>, IConfigurable
	{
		protected override string GetActionPrefix()
		{
			return "PayInStore";
		}
	}
}