using System.Web.Mvc;
using System.Web.Routing;
using cloudCommerce.Web.Framework.Routing;

namespace cloudCommerce.DevTools
{
    
	public class RouteProvider : IRouteProvider
    {
        public void RegisterRoutes(RouteCollection routes)
        {
			routes.MapRoute("cloudCommerce.DevTools",
				 "Plugin/cloudCommerce.DevTools/{action}/{id}",
				 new { controller = "DevTools", action = "Configure", id = UrlParameter.Optional },
				 new[] { "cloudCommerce.DevTools.Controllers" }
			)
			.DataTokens["area"] = "cloudCommerce.DevTools";

			//routes.MapRoute("cloudCommerce.DevTools.MyCheckout",
			//	 "MyCheckout/{action}",
			//	 new { controller = "MyCheckout", action = "MyBillingAddress" },
			//	 new[] { "cloudCommerce.DevTools.Controllers" }
			//)
			//.DataTokens["area"] = "cloudCommerce.DevTools";
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
