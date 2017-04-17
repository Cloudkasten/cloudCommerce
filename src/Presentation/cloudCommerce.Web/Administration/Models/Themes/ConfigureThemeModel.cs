using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Routing;
using cloudCommerce.Core.Domain.Stores;
using cloudCommerce.Web.Framework;
using cloudCommerce.Web.Framework.Modelling;

namespace cloudCommerce.Admin.Models.Themes
{
    public class ConfigureThemeModel : ModelBase
    {
        public string ThemeName { get; set; }

        public string ConfigurationActionName { get; set; }
        public string ConfigurationControllerName { get; set; }
        public RouteValueDictionary ConfigurationRouteValues { get; set; }

		[SmartResourceDisplayName("Admin.Common.Store")]
		public int StoreId { get; set; }
		public IList<SelectListItem> AvailableStores { get; set; }
    }
}