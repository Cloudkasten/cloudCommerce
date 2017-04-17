using System.Web.Mvc;
using System.Web.Routing;
using cloudCommerce.Web.Framework.Routing;

namespace cloudCommerce.GoogleMerchantCenter
{
    public partial class RouteProvider : IRouteProvider
    {
        public void RegisterRoutes(RouteCollection routes)
        {
			routes.MapRoute("cloudCommerce.GoogleMerchantCenter",
				 "Plugins/cloudCommerce.GoogleMerchantCenter/{action}",
				 new { controller = "FeedGoogleMerchantCenter", action = "Configure" },
				 new[] { "cloudCommerce.GoogleMerchantCenter.Controllers" }
            )
			.DataTokens["area"] = GoogleMerchantCenterFeedPlugin.SystemName;
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
