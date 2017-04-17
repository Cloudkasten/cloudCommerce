using System;
using cloudCommerce.Core.Plugins;
using cloudCommerce.Services.Localization;
using cloudCommerce.Services.Configuration;
using cloudCommerce.Services;
using System.Data.Entity.Migrations;
using cloudCommerce.Tax.Data.Migrations;

namespace cloudCommerce.Tax
{

	public partial class Plugin : BasePlugin
    {
		private readonly ICommonServices _services;

		public Plugin(ICommonServices services)
        {
			this._services = services;
        }

        public override void Install()
        {
			var settings = _services.Settings;
			var loc = _services.Localization;

			// add resources
			loc.ImportPluginResourcesFromXml(this.PluginDescriptor);
            
            base.Install();
        }

        public override void Uninstall()
        {
			var settings = _services.Settings;
			var loc = _services.Localization;

			// delete resources
			loc.DeleteLocaleStringResources(this.PluginDescriptor.ResourceRootKey);
			loc.DeleteLocaleStringResources("Plugins.Tax.CountryStateZip");
			loc.DeleteLocaleStringResources("Plugins.Tax.FixedRate");

			var migrator = new DbMigrator(new Configuration());
			migrator.Update(DbMigrator.InitialDatabase);

            base.Uninstall();
        }
    }
}