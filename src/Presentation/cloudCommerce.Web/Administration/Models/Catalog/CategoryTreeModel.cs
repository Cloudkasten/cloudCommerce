using System.Collections.Generic;
using System.Web.Mvc;
using cloudCommerce.Web.Framework;
using cloudCommerce.Web.Framework.Modelling;

namespace cloudCommerce.Admin.Models.Catalog
{
    public class CategoryTreeModel : ModelBase
    {
		public CategoryTreeModel()
		{
			AvailableStores = new List<SelectListItem>();
		}

		[SmartResourceDisplayName("Admin.Common.Store.SearchFor")]
		public int SearchStoreId { get; set; }
		public IList<SelectListItem> AvailableStores { get; set; }
    }
}