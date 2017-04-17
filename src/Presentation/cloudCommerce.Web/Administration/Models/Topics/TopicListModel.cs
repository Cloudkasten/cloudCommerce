using System.Collections.Generic;
using System.Web.Mvc;
using cloudCommerce.Web.Framework;
using cloudCommerce.Web.Framework.Modelling;

namespace cloudCommerce.Admin.Models.Topics
{
	public class TopicListModel : ModelBase
	{
		public TopicListModel()
		{
			AvailableStores = new List<SelectListItem>();
		}

		[SmartResourceDisplayName("Admin.Common.Store.SearchFor")]
		public int SearchStoreId { get; set; }
		public IList<SelectListItem> AvailableStores { get; set; }
	}
}