using System.Web.Mvc;
using System.Web.Routing;
using cloudCommerce.Web.Framework.Routing;

namespace cloudCommerce.DiscountRules
{
    public partial class RouteProvider : IRouteProvider
    {
        public void RegisterRoutes(RouteCollection routes)
        {
			routes.MapRoute("cloudCommerce.DiscountRules",
				 "Plugins/cloudCommerce.DiscountRules/{controller}/{action}",
                 new { controller = "DiscountRules", action = "Index" },
                 new[] { "cloudCommerce.DiscountRules.Controllers" }
            )
			.DataTokens["area"] = "cloudCommerce.DiscountRules";
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
