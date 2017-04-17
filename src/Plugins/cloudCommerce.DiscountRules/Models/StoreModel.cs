using System.Collections.Generic;
using System.Web.Mvc;
using cloudCommerce.Web.Framework;

namespace cloudCommerce.DiscountRules.Models
{
	public class StoreModel : DiscountRuleModelBase
    {
		public StoreModel()
        {
			AvailableStores = new List<SelectListItem>();
        }
		[SmartResourceDisplayName("Plugins.DiscountRules.Store.Fields.Store")]
		public int StoreId { get; set; }
		public IList<SelectListItem> AvailableStores { get; set; }
    }
}