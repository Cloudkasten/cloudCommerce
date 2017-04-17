using System.Web.Mvc;
using System.Web.Routing;
using cloudCommerce.Web.Framework.Routing;

namespace cloudCommerce.Tax
{
    public partial class RouteProvider : IRouteProvider
    {
        public void RegisterRoutes(RouteCollection routes)
        {
			routes.MapRoute("cloudCommerce.Tax.FixedRate",
				 "Plugins/cloudCommerce.Tax/FixedRate/{action}",
				 new { controller = "TaxFixedRate", action = "Configure" },
				 new[] { "cloudCommerce.Tax.Controllers" }
            )
			.DataTokens["area"] = "cloudCommerce.Tax";

			routes.MapRoute("cloudCommerce.Tax.ByRegion",
				 "Plugins/cloudCommerce.Tax/ByRegion/{action}",
				 new { controller = "TaxByRegion", action = "Configure" },
				 new[] { "cloudCommerce.Tax.Controllers" }
			)
			.DataTokens["area"] = "cloudCommerce.Tax";
        }

        public int Priority
        {
            get
            {
                return 0;
            }
        }
    }
}
