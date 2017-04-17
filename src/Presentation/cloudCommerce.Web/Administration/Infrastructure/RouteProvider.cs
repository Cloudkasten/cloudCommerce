using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using cloudCommerce.Web.Framework.Routing;

namespace cloudCommerce.Admin.Infrastructure
{
	public class RouteProvider : IRouteProvider
	{
		public void RegisterRoutes(RouteCollection routes)
		{
			var route = routes.MapRoute(
				"Admin_default",
				"Admin/{controller}/{action}/{id}",
				new { controller = "Home", action = "Index", area = "Admin", id = "" },
				new[] { "cloudCommerce.Admin.Controllers" }
			);
			route.DataTokens["area"] = "Admin";
		}

		public int Priority
		{
			get { return 1000; }
		}
	}
}