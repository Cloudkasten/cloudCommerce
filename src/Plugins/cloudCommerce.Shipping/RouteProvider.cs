using System.Web.Mvc;
using System.Web.Routing;
using cloudCommerce.Web.Framework.Routing;

namespace cloudCommerce.Shipping
{
    public partial class RouteProvider : IRouteProvider
    {
        public void RegisterRoutes(RouteCollection routes)
        {
            routes.MapRoute("cloudCommerce.Shipping.ByTotal",
                 "Plugins/ShippingByTotal/{action}",
                 new { controller = "ByTotal", action = "Configure" },
                 new[] { "cloudCommerce.Shipping.Controllers" }
            )
            .DataTokens["area"] = "cloudCommerce.Shipping";

            routes.MapRoute("cloudCommerce.Shipping.FixedRate",
                 "Plugins/FixedRate/{action}",
                 new { controller = "FixedRate", action = "Configure" },
                 new[] { "cloudCommerce.Shipping.Controllers" }
            )
            .DataTokens["area"] = "cloudCommerce.Shipping";
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
