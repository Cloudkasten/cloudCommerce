using cloudCommerce.Core.Plugins;
using cloudCommerce.OfflinePayment.Settings;

namespace cloudCommerce.OfflinePayment
{
	[SystemName("Payments.Prepayment")]
	[FriendlyName("Prepayment")]
	[DisplayOrder(1)]
	public class PrepaymentProvider : OfflinePaymentProviderBase<PrepaymentPaymentSettings>, IConfigurable
	{
		protected override string GetActionPrefix()
		{
			return "Prepayment";
		}
	}
}