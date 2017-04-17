using System.Web.Routing;

namespace cloudCommerce.Web.Framework.Routing
{
    public interface IRouteProvider
    {
        void RegisterRoutes(RouteCollection routes);

        int Priority { get; }
    }
}
