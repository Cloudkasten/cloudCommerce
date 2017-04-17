using System.Web.Mvc;
using System.Web.Routing;
using cloudCommerce.Web.Framework.Routing;

namespace cloudCommerce.ShippingByWeight
{
    public partial class RouteProvider : IRouteProvider
    {
        public void RegisterRoutes(RouteCollection routes)
        {
            routes.MapRoute("cloudCommerce.ShippingByWeight",
                 "Plugins/ShippingByWeight/{action}",
                 new { controller = "ShippingByWeight", action = "Configure" },
                 new[] { "cloudCommerce.ShippingByWeight.Controllers" }
            )
            .DataTokens["area"] = "cloudCommerce.ShippingByWeight";
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
