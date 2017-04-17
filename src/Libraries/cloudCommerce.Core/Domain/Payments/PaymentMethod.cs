using System.Runtime.Serialization;
using cloudCommerce.Core.Domain.Localization;

namespace cloudCommerce.Core.Domain.Payments
{
	/// <summary>
	/// Represents a payment method
	/// </summary>
	[DataContract]
	public partial class PaymentMethod : BaseEntity, ILocalizedEntity
	{
		/// <summary>
		/// Gets or sets the payment method system name
		/// </summary>
		[DataMember]
		public string PaymentMethodSystemName { get; set; }

		/// <summary>
		/// Gets or sets the full description
		/// </summary>
		[DataMember]
		public string FullDescription { get; set; }
	}
}
