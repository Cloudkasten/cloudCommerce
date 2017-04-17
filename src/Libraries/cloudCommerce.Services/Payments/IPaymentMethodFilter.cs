using System.Collections.Generic;
using cloudCommerce.Core.Domain.Customers;
using cloudCommerce.Core.Domain.Orders;
using cloudCommerce.Core.Plugins;

namespace cloudCommerce.Services.Payments
{
	public partial interface IPaymentMethodFilter
	{
		/// <summary>
		/// Gets a value indicating whether a payment method should be filtered out
		/// </summary>
		/// <param name="request">Payment filter request</param>
		/// <returns><c>true</c> filter out method, <c>false</c> do not filter out method</returns>
		bool IsExcluded(PaymentFilterRequest request);

		/// <summary>
		/// Get URL for filter configuration
		/// </summary>
		/// <param name="systemName">Payment provider system name</param>
		/// <returns>URL for filter configuration</returns>
		string GetConfigurationUrl(string systemName);
	}


	public partial class PaymentFilterRequest
	{
		/// <summary>
		/// The payment method to be checked
		/// </summary>
		public Provider<IPaymentMethod> PaymentMethod { get; set; }

		/// <summary>
		/// The context shopping cart
		/// </summary>
		public IList<OrganizedShoppingCartItem> Cart { get; set; }

		/// <summary>
		/// The context store identifier
		/// </summary>
		public int StoreId { get; set; }

		/// <summary>
		/// The context customer
		/// </summary>
		public Customer Customer { get; set; }
	}
}
