using System.Collections.Generic;
using System.Web.Mvc;
using cloudCommerce.Web.Framework;
using cloudCommerce.Web.Framework.Modelling;

namespace cloudCommerce.Admin.Models.Messages
{
	public class MessageTemplateListModel : ModelBase
	{
		public MessageTemplateListModel()
		{
			AvailableStores = new List<SelectListItem>();
		}

		[SmartResourceDisplayName("Admin.Common.Store.SearchFor")]
		public int SearchStoreId { get; set; }
		public IList<SelectListItem> AvailableStores { get; set; }
	}
}