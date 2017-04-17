using System.Web.Mvc;
using System.Web.Routing;
using cloudCommerce.Web.Framework.Routing;

namespace cloudCommerce.Clickatell
{
    public partial class RouteProvider : IRouteProvider
    {
        public void RegisterRoutes(RouteCollection routes)
        {
            routes.MapRoute("cloudCommerce.Clickatell",
				 "Plugins/cloudCommerce.Clickatell/{action}",
                 new { controller = "SmsClickatell", action = "Configure" },
                 new[] { "cloudCommerce.Clickatell.Controllers" }
            )
			.DataTokens["area"] = "cloudCommerce.Clickatell";
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
