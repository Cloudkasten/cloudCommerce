using cloudCommerce.Core.Domain.Customers;
using cloudCommerce.Core.Domain.Discounts;
using cloudCommerce.Core.Domain.Stores;

namespace cloudCommerce.Services.Discounts
{
    /// <summary>
    /// Represents a discount requirement request
    /// </summary>
    public partial class CheckDiscountRequirementRequest
    {
        /// <summary>
        /// Gets or sets the discount
        /// </summary>
        public DiscountRequirement DiscountRequirement { get; set; }

        /// <summary>
        /// Gets or sets the customer
        /// </summary>
        public Customer Customer { get; set; }

		/// <summary>
		/// Gets or sets the store
		/// </summary>
		public Store Store { get; set; }
    }
}
