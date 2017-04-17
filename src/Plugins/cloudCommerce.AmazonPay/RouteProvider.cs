using System.Web.Mvc;
using System.Web.Routing;
using cloudCommerce.AmazonPay.Services;
using cloudCommerce.Web.Framework.Routing;

namespace cloudCommerce.AmazonPay
{
	public class RouteProvider : IRouteProvider
	{
		public void RegisterRoutes(RouteCollection routes)
		{
			routes.MapRoute("cloudCommerce.AmazonPay",
					"Plugins/cloudCommerce.AmazonPay/{controller}/{action}",
					new { controller = "AmazonPay" },
					new[] { "cloudCommerce.AmazonPay.Controllers" }
			)
			.DataTokens["area"] = AmazonPayCore.SystemName;

			// for backward compatibility (IPN!)
			routes.MapRoute("cloudCommerce.AmazonPay.Legacy",
					"Plugins/PaymentsAmazonPay/{action}",
					new { controller = "AmazonPay" },
					new[] { "cloudCommerce.AmazonPay.Controllers" }
			)
			.DataTokens["area"] = AmazonPayCore.SystemName;
		}

		public int Priority { get { return 0; } }
	}
}