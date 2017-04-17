using cloudCommerce.Core.Domain.Payments;
using cloudCommerce.Core.Plugins;
using cloudCommerce.OfflinePayment.Settings;
using cloudCommerce.Services.Payments;

namespace cloudCommerce.OfflinePayment
{
	[SystemName("Payments.DirectDebit")]
	[FriendlyName("Direct Debit")]
	[DisplayOrder(1)]
	public class DirectDebitProvider : OfflinePaymentProviderBase<DirectDebitPaymentSettings>, IConfigurable
	{
		public override ProcessPaymentResult ProcessPayment(ProcessPaymentRequest processPaymentRequest)
		{
			var result = new ProcessPaymentResult();
			result.AllowStoringDirectDebit = true;
			result.NewPaymentStatus = PaymentStatus.Pending;
			return result;
		}

		protected override string GetActionPrefix()
		{
			return "DirectDebit";
		}

		public override bool RequiresInteraction
		{
			get
			{
				return true;
			}
		}
	}
}