using System.Collections.Generic;
using System.Web.Mvc;
using cloudCommerce.Web.Framework.Modelling;

namespace cloudCommerce.Admin.Models.Orders
{
	public class CheckoutAttributeListModel : ModelBase
    {
		public int GridPageSize { get; set; }

		public IList<SelectListItem> AvailableStores { get; set; }
	}
}