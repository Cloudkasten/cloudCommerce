using System;
using System.Linq;
using System.Web.Routing;
using cloudCommerce.Core.Logging;
using cloudCommerce.Core.Plugins;
using cloudCommerce.Services.Common;
using cloudCommerce.Services.Configuration;

namespace cloudCommerce.DevTools
{
	public class DevToolsPlugin : BasePlugin, IConfigurable
    {
		private readonly ISettingService _settingService;

		public DevToolsPlugin(ISettingService settingService)
        {
			this._settingService = settingService;
			this.Logger = NullLogger.Instance;
        }

		public ILogger Logger { get; set; }

        public void GetConfigurationRoute(out string actionName, out string controllerName, out RouteValueDictionary routeValues)
        {
            actionName = "Configure";
            controllerName = "DevTools";
			routeValues = new RouteValueDictionary() { { "area", "cloudCommerce.DevTools" } };
        }

        public override void Install()
        {
			_settingService.SaveSetting(new ProfilerSettings());
			base.Install();
			Logger.Information(string.Format("Plugin installed: SystemName: {0}, Version: {1}, Description: '{2}'", PluginDescriptor.SystemName, PluginDescriptor.Version, PluginDescriptor.FriendlyName));
        }

        /// <summary>
        /// Uninstall plugin
        /// </summary>
        public override void Uninstall()
        {
			_settingService.DeleteSetting<ProfilerSettings>();
			base.Uninstall();
        }
    }
}
