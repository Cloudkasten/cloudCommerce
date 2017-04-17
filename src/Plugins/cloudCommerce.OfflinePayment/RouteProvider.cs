using System.Web.Mvc;
using System.Web.Routing;
using cloudCommerce.Web.Framework.Routing;

namespace cloudCommerce.OfflinePayment
{
    public partial class RouteProvider : IRouteProvider
    {
        public void RegisterRoutes(RouteCollection routes)
        {
			routes.MapRoute("cloudCommerce.OfflinePayment",
				 "Plugins/cloudCommerce.OfflinePayment/{action}",
				 new { controller = "OfflinePayment", action = "Index" },
				 new[] { "cloudCommerce.OfflinePayment.Controllers" }
            )
			.DataTokens["area"] = "cloudCommerce.OfflinePayment";
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
