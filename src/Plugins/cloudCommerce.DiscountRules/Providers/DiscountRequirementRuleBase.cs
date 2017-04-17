using System;
using cloudCommerce.Core;
using cloudCommerce.Core.Plugins;
using cloudCommerce.Services.Discounts;

namespace cloudCommerce.DiscountRules
{
	public abstract class DiscountRequirementRuleBase : IDiscountRequirementRule
    {
		public abstract bool CheckRequirement(CheckDiscountRequirementRequest request);

        public string GetConfigurationUrl(int discountId, int? discountRequirementId)
        {
			string result = "Plugins/cloudCommerce.DiscountRules/DiscountRules/{0}?discountId={1}".FormatInvariant(GetActionName(), discountId);
            if (discountRequirementId.HasValue)
			{
                result += string.Format("&discountRequirementId={0}", discountRequirementId.Value);
			}
			return result;
        }

		protected abstract string GetActionName();
    }
}