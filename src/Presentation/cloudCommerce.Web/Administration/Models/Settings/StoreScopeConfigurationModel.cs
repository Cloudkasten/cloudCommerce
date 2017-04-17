using System.Collections.Generic;
using System.Web.Mvc;
using cloudCommerce.Web.Framework.Modelling;

namespace cloudCommerce.Admin.Models.Settings
{
	public partial class StoreScopeConfigurationModel : ModelBase
	{
		public StoreScopeConfigurationModel()
		{
			AllStores = new List<SelectListItem>();
		}

		public int StoreId { get; set; }
		public IList<SelectListItem> AllStores { get; set; }
	}
}