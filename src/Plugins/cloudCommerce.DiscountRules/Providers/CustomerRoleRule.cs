using System;
using System.Linq;
using cloudCommerce.Core;
using cloudCommerce.Core.Plugins;
using cloudCommerce.Services.Discounts;
using cloudCommerce.Services.Localization;
using cloudCommerce.Services.Configuration;

namespace cloudCommerce.DiscountRules
{
	[SystemName("DiscountRequirement.MustBeAssignedToCustomerRole")]
	[FriendlyName("Must be assigned to customer role")]
	[DisplayOrder(0)]
	public partial class CustomerRoleRule : DiscountRequirementRuleBase
    {
		public override bool CheckRequirement(CheckDiscountRequirementRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("request");

            if (request.DiscountRequirement == null)
                throw new SmartException("Discount requirement is not set");

            if (request.Customer == null)
                return false;

            if (!request.DiscountRequirement.RestrictedToCustomerRoleId.HasValue)
                return false;

            foreach (var customerRole in request.Customer.CustomerRoles.Where(cr => cr.Active).ToList())
                if (request.DiscountRequirement.RestrictedToCustomerRoleId == customerRole.Id)
                    return true;

            return false;
        }

		protected override string GetActionName()
		{
			return "CustomerRole";
		}

	}
}