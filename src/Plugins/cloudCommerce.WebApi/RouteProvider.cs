using System.Web.Mvc;
using System.Web.Routing;
using cloudCommerce.Web.Framework.Routing;
using cloudCommerce.Web.Framework.WebApi;

namespace cloudCommerce.WebApi
{
	public partial class RouteProvider : IRouteProvider
	{
		public void RegisterRoutes(RouteCollection routes)
		{
            routes.MapRoute("cloudCommerce.WebApi.Action",
				"Plugins/cloudCommerce.WebApi/{action}", 
				new { controller = "WebApi" }, 
				new[] { "cloudCommerce.WebApi.Controllers" }
			)
			.DataTokens["area"] = WebApiGlobal.PluginSystemName;
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
