using System;
using cloudCommerce.Core;
using cloudCommerce.Core.Plugins;
using cloudCommerce.Services.Discounts;
using cloudCommerce.Services.Localization;

namespace cloudCommerce.DiscountRules
{
	[SystemName("DiscountRequirement.Store")]
	[FriendlyName("Restricted to store")]
	[DisplayOrder(30)]
	public partial class StoreRule : DiscountRequirementRuleBase
    {
        public override bool CheckRequirement(CheckDiscountRequirementRequest request)
        {
			if (request == null)
				throw new ArgumentNullException("request");

			if (request.DiscountRequirement == null)
				throw new SmartException("Discount requirement is not set");

			if (request.Customer == null)
				return false;

			var storeId = request.DiscountRequirement.RestrictedToStoreId ?? 0;

			if (storeId == 0)
				return false;

			bool result = request.Store.Id == storeId;
			return result;
        }

		protected override string GetActionName()
		{
			return "Store";
		}
        
    }
}