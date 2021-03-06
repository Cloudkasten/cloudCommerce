using System;
using cloudCommerce.Core;
using cloudCommerce.Core.Plugins;
using cloudCommerce.Services.Discounts;
using cloudCommerce.Services.Localization;

namespace cloudCommerce.DiscountRules
{
    [SystemName("DiscountRequirement.BillingCountryIs")]
	[FriendlyName("Billing country is")]
	[DisplayOrder(5)]
	public partial class BillingCountryRule : DiscountRequirementRuleBase
    {
		public override bool CheckRequirement(CheckDiscountRequirementRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("request");
            
            if (request.DiscountRequirement == null)
                throw new SmartException("Discount requirement is not set");

            if (request.Customer == null)
                return false;

            if (request.Customer.BillingAddress == null)
                return false;

            if (request.DiscountRequirement.BillingCountryId == 0)
                return false;

            bool result = request.Customer.BillingAddress.CountryId == request.DiscountRequirement.BillingCountryId;
            return result;
        }

		protected override string GetActionName()
        {
			return "BillingCountry";
        }

	}
}