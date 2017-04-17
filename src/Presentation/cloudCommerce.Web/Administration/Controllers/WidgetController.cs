using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using cloudCommerce.Admin.Models.Cms;
using cloudCommerce.Core.Domain.Cms;
using cloudCommerce.Core.Plugins;
using cloudCommerce.Services.Cms;
using cloudCommerce.Services.Configuration;
using cloudCommerce.Services.Security;
using cloudCommerce.Web.Framework;
using cloudCommerce.Web.Framework.Controllers;
using cloudCommerce.Web.Framework.Plugins;
using cloudCommerce.Web.Framework.Security;
using Telerik.Web.Mvc;

namespace cloudCommerce.Admin.Controllers
{
	[AdminAuthorize]
    public partial class WidgetController : AdminControllerBase
	{
		#region Fields

        private readonly IWidgetService _widgetService;
        private readonly IPermissionService _permissionService;
        private readonly ISettingService _settingService;
        private readonly WidgetSettings _widgetSettings;
	    private readonly IPluginFinder _pluginFinder;
		private readonly PluginMediator _pluginMediator;

	    #endregion

		#region Constructors

        public WidgetController(
			IWidgetService widgetService,
            IPermissionService permissionService, 
			ISettingService settingService,
            WidgetSettings widgetSettings, 
			IPluginFinder pluginFinder,
			PluginMediator pluginMediator)
		{
            this._widgetService = widgetService;
            this._permissionService = permissionService;
            this._settingService = settingService;
            this._widgetSettings = widgetSettings;
            this._pluginFinder = pluginFinder;
			this._pluginMediator = pluginMediator;
		}

		#endregion 
        
        #region Methods
        
        public ActionResult Index()
        {
            return RedirectToAction("Providers");
        }

		public ActionResult Providers()
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageWidgets))
                return AccessDeniedView();

            var widgetsModel = new List<WidgetModel>();
            var widgets = _widgetService.LoadAllWidgets();
            foreach (var widget in widgets)
            {
                var model = _pluginMediator.ToProviderModel<IWidget, WidgetModel>(widget);
                model.IsActive = widget.IsWidgetActive(_widgetSettings);
                widgetsModel.Add(model);
            }

			return View(widgetsModel);
        }

		public ActionResult ActivateProvider(string systemName, bool activate)
		{
			if (!_permissionService.Authorize(StandardPermissionProvider.ManageWidgets))
				return AccessDeniedView();
			
			var widget = _widgetService.LoadWidgetBySystemName(systemName);
			if (widget.IsWidgetActive(_widgetSettings))
			{
				if (!activate)
				{
					// mark as disabled
					_widgetSettings.ActiveWidgetSystemNames.Remove(widget.Metadata.SystemName);
					_settingService.SaveSetting(_widgetSettings);
				}
			}
			else
			{
				if (activate)
				{
					// mark as active
					_widgetSettings.ActiveWidgetSystemNames.Add(widget.Metadata.SystemName);
					_settingService.SaveSetting(_widgetSettings);
				}
			}

			return RedirectToAction("Providers");
		}

        #endregion
    }
}
