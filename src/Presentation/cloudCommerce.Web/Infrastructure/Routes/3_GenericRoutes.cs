using System.Web.Mvc;
using System.Web.Routing;
using cloudCommerce.Web.Framework.Localization;
using cloudCommerce.Web.Framework.Routing;
using cloudCommerce.Web.Framework.Seo;

namespace cloudCommerce.Web.Infrastructure
{
    public partial class SeoRoutes : IRouteProvider
    {
        public void RegisterRoutes(RouteCollection routes)
        {
            //generic URLs
            routes.MapGenericPathRoute("GenericUrl",
                "{*generic_se_name}",
                new { controller = "Common", action = "GenericUrl" },
                new[] { "cloudCommerce.Web.Controllers" });

			// Routes solely needed for URL creation, NOT for route matching.
            routes.MapLocalizedRoute("Product",
                "{SeName}",
                new { controller = "Product", action = "Product" },
                new[] { "cloudCommerce.Web.Controllers" });
            routes.MapLocalizedRoute("Category",
                "{SeName}",
                new { controller = "Catalog", action = "Category" },
                new[] { "cloudCommerce.Web.Controllers" });
            routes.MapLocalizedRoute("Manufacturer",
                "{SeName}",
                new { controller = "Catalog", action = "Manufacturer" },
                new[] { "cloudCommerce.Web.Controllers" });
            routes.MapLocalizedRoute("NewsItem",
	            "{SeName}",
	            new { controller = "News", action = "NewsItem" },
	            new[] { "cloudCommerce.Web.Controllers" });
            routes.MapLocalizedRoute("BlogPost",
                "{SeName}",
                new { controller = "Blog", action = "BlogPost" },
                new[] { "cloudCommerce.Web.Controllers" });

			// TODO: actually this one's never reached, because the "GenericUrl" route
			// at the top handles this.
			routes.MapLocalizedRoute("PageNotFound",
				"{*path}",
				new { controller = "Error", action = "NotFound" },
				new[] { "cloudCommerce.Web.Controllers" });
        }

        public int Priority
        {
            get
            {
                return int.MinValue;
            }
        }
    }
}
