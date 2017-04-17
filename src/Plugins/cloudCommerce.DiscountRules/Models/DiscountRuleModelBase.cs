using System.Collections.Generic;
using System.Web.Mvc;

namespace cloudCommerce.DiscountRules.Models
{ 
	public abstract class DiscountRuleModelBase
    {
		public int DiscountId { get; set; }
		public int RequirementId { get; set; }
    }
}