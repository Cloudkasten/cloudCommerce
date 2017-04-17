using System.Web.Mvc;
using System.Web.Routing;
using cloudCommerce.Web.Framework.Routing;

namespace cloudCommerce.PayPal
{
    public partial class RouteProvider : IRouteProvider
    {
        public void RegisterRoutes(RouteCollection routes)
        {
            routes.MapRoute("cloudCommerce.PayPalExpress",
                "Plugins/cloudCommerce.PayPal/{controller}/{action}",
                new { controller = "PayPalExpress", action = "Index" },
                new[] { "cloudCommerce.PayPal.Controllers" }
            )
            .DataTokens["area"] = "cloudCommerce.PayPal";

            routes.MapRoute("cloudCommerce.PayPalDirect",
                "Plugins/cloudCommerce.PayPal/{controller}/{action}",
                new { controller = "PayPalDirect", action = "Index" },
                new[] { "cloudCommerce.PayPal.Controllers" }
            )
            .DataTokens["area"] = "cloudCommerce.PayPal";

            routes.MapRoute("cloudCommerce.PayPalStandard",
                "Plugins/cloudCommerce.PayPal/{controller}/{action}",
                new { controller = "PayPalStandard", action = "Index" },
                new[] { "cloudCommerce.PayPal.Controllers" }
            )
            .DataTokens["area"] = "cloudCommerce.PayPal";

			routes.MapRoute("cloudCommerce.PayPalPlus",
				"Plugins/cloudCommerce.PayPal/{controller}/{action}",
				new { controller = "PayPalPlus", action = "Index" },
				new[] { "cloudCommerce.PayPal.Controllers" }
			)
			.DataTokens["area"] = Plugin.SystemName;



			//Legacay Routes
			routes.MapRoute("cloudCommerce.PayPalExpress.IPN",
                 "Plugins/PaymentPayPalExpress/IPNHandler",
                 new { controller = "PayPalExpress", action = "IPNHandler" },
                 new[] { "cloudCommerce.PayPal.Controllers" }
            )
            .DataTokens["area"] = "cloudCommerce.PayPal";

            routes.MapRoute("cloudCommerce.PayPalDirect.IPN",
                 "Plugins/PaymentPayPalDirect/IPNHandler",
                 new { controller = "PayPalDirect", action = "IPNHandler" },
                 new[] { "cloudCommerce.PayPal.Controllers" }
            )
            .DataTokens["area"] = "cloudCommerce.PayPal";

            routes.MapRoute("cloudCommerce.PayPalStandard.IPN",
                 "Plugins/PaymentPayPalStandard/IPNHandler",
                 new { controller = "PayPalStandard", action = "IPNHandler" },
                 new[] { "cloudCommerce.PayPal.Controllers" }
            )
            .DataTokens["area"] = "cloudCommerce.PayPal";

            routes.MapRoute("cloudCommerce.PayPalStandard.PDT",
                 "Plugins/PaymentPayPalStandard/PDTHandler",
                 new { controller = "PayPalStandard", action = "PDTHandler" },
                 new[] { "cloudCommerce.PayPal.Controllers" }
            )
            .DataTokens["area"] = "cloudCommerce.PayPal";

            routes.MapRoute("cloudCommerce.PayPalExpress.RedirectFromPaymentInfo",
                 "Plugins/PaymentPayPalExpress/RedirectFromPaymentInfo",
                 new { controller = "PayPalExpress", action = "RedirectFromPaymentInfo" },
                 new[] { "cloudCommerce.PayPal.Controllers" }
            )
            .DataTokens["area"] = "cloudCommerce.PayPal";

            routes.MapRoute("cloudCommerce.PayPalStandard.CancelOrder",
                 "Plugins/PaymentPayPalStandard/CancelOrder",
                 new { controller = "PayPalStandard", action = "CancelOrder" },
                 new[] { "cloudCommerce.PayPal.Controllers" }
            )
            .DataTokens["area"] = "cloudCommerce.PayPal";
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
