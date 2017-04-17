using System.Web.Mvc;
using System.Web.Routing;
using cloudCommerce.FacebookAuth.Core;
using cloudCommerce.Web.Framework.Routing;

namespace cloudCommerce.FacebookAuth
{
    public partial class RouteProvider : IRouteProvider
    {
        public void RegisterRoutes(RouteCollection routes)
        {
			routes.MapRoute("cloudCommerce.FacebookAuth",
				 "Plugins/cloudCommerce.FacebookAuth/{action}",
				 new { controller = "ExternalAuthFacebook" },
				 new[] { "cloudCommerce.FacebookAuth.Controllers" }
			)
			.DataTokens["area"] = Provider.SystemName;
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
