using System.Collections.Generic;
using System.Web.Mvc;
using cloudCommerce.Web.Framework;

namespace cloudCommerce.DiscountRules.Models
{
	public class HasAllProductsModel : DiscountRuleModelBase
    {
		[SmartResourceDisplayName("Plugins.DiscountRules.HasAllProducts.Fields.Products")]
		public string Products { get; set; }
    }
}