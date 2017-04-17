using System.Collections.Generic;
using System.Web.Mvc;
using cloudCommerce.Web.Framework;

namespace cloudCommerce.DiscountRules.Models
{
	public class HasOneProductModel : DiscountRuleModelBase
    {
		[SmartResourceDisplayName("Plugins.DiscountRules.HasOneProduct.Fields.Products")]
		public string Products { get; set; }
    }
}