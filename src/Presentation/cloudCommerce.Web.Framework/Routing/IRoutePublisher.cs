using System.Web.Routing;

namespace cloudCommerce.Web.Framework.Routing
{
    public interface IRoutePublisher
    {
        void RegisterRoutes(RouteCollection routeCollection);
    }
}
