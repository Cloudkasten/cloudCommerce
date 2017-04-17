using System.Web.Mvc;
using System.Web.Routing;
using cloudCommerce.Web.Framework.Routing;

namespace cloudCommerce.GoogleAnalytics
{
    public partial class RouteProvider : IRouteProvider
    {
        public void RegisterRoutes(RouteCollection routes)
        {
            routes.MapRoute("cloudCommerce.GoogleAnalytics",
				 "Plugins/cloudCommerce.GoogleAnalytics/{action}",
                 new { controller = "WidgetsGoogleAnalytics", action = "Configure" },
                 new[] { "cloudCommerce.GoogleAnalytics.Controllers" }
            )
			.DataTokens["area"] = "cloudCommerce.GoogleAnalytics";
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
