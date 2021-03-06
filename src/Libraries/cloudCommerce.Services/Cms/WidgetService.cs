using System;
using System.Collections.Generic;
using System.Linq;
using cloudCommerce.Collections;
using cloudCommerce.Core.Caching;
using cloudCommerce.Core.Domain.Cms;
using cloudCommerce.Core.Plugins;
using cloudCommerce.Services.Configuration;

namespace cloudCommerce.Services.Cms
{
    /// <summary>
    /// Widget service
    /// </summary>
    public partial class WidgetService : IWidgetService
    {

        #region Fields & Consts

		private const string WIDGETS_ACTIVE_KEY = "cloudCommerce.widgets.active-{0}";
		private const string WIDGETS_ZONEMAPPED_KEY = "cloudCommerce.widgets.zonemapped-{0}";

        private readonly IPluginFinder _pluginFinder;
        private readonly WidgetSettings _widgetSettings;
		private readonly ISettingService _settingService;
		private readonly IProviderManager _providerManager;
		private readonly ICacheManager _cacheManager;

        #endregion
        
        #region Ctor

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="pluginFinder">Plugin finder</param>
        /// <param name="widgetSettings">Widget settings</param>
		/// <param name="pluginService">Plugin service</param>
		public WidgetService(
			IPluginFinder pluginFinder, 
			WidgetSettings widgetSettings, 
			ISettingService settingService, 
			IProviderManager providerManager,
			ICacheManager cacheManager)
        {
            this._pluginFinder = pluginFinder;
            this._widgetSettings = widgetSettings;
			this._settingService = settingService;
			this._providerManager = providerManager;
			this._cacheManager = cacheManager;
        }

        #endregion

        #region Methods

		/// <summary>
		/// Load all widgets
		/// </summary>
		/// <param name="storeId">Load records allows only in specified store; pass 0 to load all records</param>
		/// <returns>Widgets</returns>
		public virtual IEnumerable<Provider<IWidget>> LoadAllWidgets(int storeId = 0)
		{
			return _providerManager.GetAllProviders<IWidget>(storeId);
		}

        /// <summary>
        /// Load active widgets
        /// </summary>
		/// <param name="storeId">Load records allows only in specified store; pass 0 to load all records</param>
        /// <returns>Widgets</returns>
		public virtual IEnumerable<Provider<IWidget>> LoadActiveWidgets(int storeId = 0)
        {
			var activeWidgets = _cacheManager.Get(WIDGETS_ACTIVE_KEY.FormatInvariant(storeId), () => {
				var allWigets = LoadAllWidgets(storeId);
				return allWigets.Where(p => _widgetSettings.ActiveWidgetSystemNames.Contains(p.Metadata.SystemName, StringComparer.InvariantCultureIgnoreCase));			
			});

			return activeWidgets;
        }

        /// <summary>
        /// Load active widgets
        /// </summary>
        /// <param name="widgetZone">Widget zone</param>
		/// <param name="storeId">Load records allows only in specified store; pass 0 to load all records</param>
        /// <returns>Widgets</returns>
		public virtual IEnumerable<Provider<IWidget>> LoadActiveWidgetsByWidgetZone(string widgetZone, int storeId = 0)
        {
            if (widgetZone.IsEmpty())
				return Enumerable.Empty<Provider<IWidget>>();

			var mappedWidgets = _cacheManager.Get(WIDGETS_ZONEMAPPED_KEY.FormatInvariant(storeId), () => {
				var activeWidgets = LoadActiveWidgets(storeId);
				var map = new Multimap<string, Provider<IWidget>>();

				foreach (var widget in activeWidgets)
				{
					var zones = widget.Value.GetWidgetZones();
					if (zones != null && zones.Any())
					{
						foreach (var zone in zones.Select(x => x.ToLower()))
						{
							map.Add(zone, widget);
						}
					}
				}

				return map;
			});

			widgetZone = widgetZone.ToLower();
			if (mappedWidgets.ContainsKey(widgetZone))
			{
				return mappedWidgets[widgetZone];
			}

			return Enumerable.Empty<Provider<IWidget>>();
        }

        /// <summary>
        /// Load widget by system name
        /// </summary>
         /// <param name="systemName">System name</param>
        /// <returns>Found widget</returns>
		public virtual Provider<IWidget> LoadWidgetBySystemName(string systemName)
        {
			return _providerManager.GetProvider<IWidget>(systemName);
        }

        #endregion
    }
}
