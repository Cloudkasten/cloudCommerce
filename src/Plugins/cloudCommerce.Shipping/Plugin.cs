using System;
using System.Data.Entity.Migrations;
using System.Web.Routing;
using cloudCommerce.Core;
using cloudCommerce.Core.Domain.Shipping;
using cloudCommerce.Core.Plugins;
using cloudCommerce.Shipping.Data;
using cloudCommerce.Shipping.Data.Migrations;
using cloudCommerce.Shipping.Services;
using cloudCommerce.Services.Catalog;
using cloudCommerce.Services.Configuration;
using cloudCommerce.Services.Localization;
using cloudCommerce.Core.Logging;
using cloudCommerce.Services.Shipping;
using cloudCommerce.Services.Shipping.Tracking;

namespace cloudCommerce.Shipping
{
	public class Plugin : BasePlugin
    {
        private readonly ILogger _logger;
        private readonly ISettingService _settingService;
        private readonly ILocalizationService _localizationService;
        private readonly ByTotalObjectContext _objectContext;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="logger">Logger</param>
        /// /// <param name="settingService">Settings service</param>
        /// /// <param name="settingService">Localization service</param>
        public Plugin(ILogger logger,
            ISettingService settingService,
            ILocalizationService localizationService,
            ByTotalObjectContext objectContext)
        {
            this._logger = logger;
            this._settingService = settingService;
            this._localizationService = localizationService;
            this._objectContext = objectContext;
        }

        /// <summary>
        /// Install the plugin
        /// </summary>
        public override void Install()
        {            
            var shippingByTotalSettings = new ShippingByTotalSettings()
            {
                LimitMethodsToCreated = false,
                SmallQuantityThreshold = 0,
                SmallQuantitySurcharge = 0
            };
            _settingService.SaveSetting(shippingByTotalSettings);

            _localizationService.ImportPluginResourcesFromXml(this.PluginDescriptor);

            base.Install();

            _logger.Information(string.Format("Plugin installed: SystemName: {0}, Version: {1}, Description: '{2}'", PluginDescriptor.SystemName, PluginDescriptor.Version, PluginDescriptor.FriendlyName));
        }

        /// <summary>
        /// Uninstall the plugin
        /// </summary>
        public override void Uninstall()
        {
            _settingService.DeleteSetting<ShippingByTotalSettings>();

			_localizationService.DeleteLocaleStringResources(PluginDescriptor.ResourceRootKey);

			var migrator = new DbMigrator(new Configuration());
			migrator.Update(DbMigrator.InitialDatabase);

            _localizationService.DeleteLocaleStringResources("Plugins.FriendlyName.Shipping.FixedRateShipping", false);

            base.Uninstall();
        }
    }
}
