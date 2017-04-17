using System.Web.Routing;
using NUnit.Framework;
using cloudCommerce.Core.Data;

namespace cloudCommerce.Web.MVC.Tests.Public.Infrastructure
{
    [TestFixture]
    public abstract class RoutesTestsBase
    {
        [SetUp]
        public void Setup()
        {
            //var typeFinder = new WebAppTypeFinder();
            //var routePublisher = new RoutePublisher(typeFinder);
            //routePublisher.RegisterRoutes(RouteTable.Routes);

			DataSettings.SetTestMode(true);

			new cloudCommerce.Web.Infrastructure.StoreRoutes().RegisterRoutes(RouteTable.Routes);
			new cloudCommerce.Web.Infrastructure.GeneralRoutes().RegisterRoutes(RouteTable.Routes);
			new cloudCommerce.Web.Infrastructure.SeoRoutes().RegisterRoutes(RouteTable.Routes);
        }

        [TearDown]
        public void TearDown()
        {
            RouteTable.Routes.Clear();
        }
    }
}
