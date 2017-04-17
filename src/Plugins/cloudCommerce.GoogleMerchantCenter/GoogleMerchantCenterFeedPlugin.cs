using System.Data.Entity.Migrations;
using System.Web.Routing;
using cloudCommerce.Core.Plugins;
using cloudCommerce.GoogleMerchantCenter.Data.Migrations;
using cloudCommerce.GoogleMerchantCenter.Services;
using cloudCommerce.Services;

namespace cloudCommerce.GoogleMerchantCenter
{
    public class GoogleMerchantCenterFeedPlugin : BasePlugin, IConfigurable
    {
        private readonly IGoogleFeedService _googleFeedService;
		private readonly ICommonServices _services;

        public GoogleMerchantCenterFeedPlugin(
			IGoogleFeedService googleFeedService,
			ICommonServices services)
        {
            _googleFeedService = googleFeedService;
			_services = services;
        }

		public static string SystemName
		{
			get { return "cloudCommerce.GoogleMerchantCenter"; }
		}

        /// <summary>
        /// Gets a route for provider configuration
        /// </summary>
        /// <param name="actionName">Action name</param>
        /// <param name="controllerName">Controller name</param>
        /// <param name="routeValues">Route values</param>
        public void GetConfigurationRoute(out string actionName, out string controllerName, out RouteValueDictionary routeValues)
        {
            actionName = "Configure";
			controllerName = "FeedGoogleMerchantCenter";
			routeValues = new RouteValueDictionary() { { "Namespaces", "cloudCommerce.GoogleMerchantCenter.Controllers" }, { "area", SystemName } };
        }

        /// <summary>
        /// Install plugin
        /// </summary>
        public override void Install()
        {
			_services.Localization.ImportPluginResourcesFromXml(this.PluginDescriptor);

            base.Install();
        }

        /// <summary>
        /// Uninstall plugin
        /// </summary>
        public override void Uninstall()
        {
			_services.Localization.DeleteLocaleStringResources(PluginDescriptor.ResourceRootKey);

			var migrator = new DbMigrator(new Configuration());
			migrator.Update(DbMigrator.InitialDatabase);

            base.Uninstall();
        }
    }
}
