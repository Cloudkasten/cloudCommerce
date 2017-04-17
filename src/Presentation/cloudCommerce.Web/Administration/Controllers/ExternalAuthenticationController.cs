using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using cloudCommerce.Admin.Models.ExternalAuthentication;
using cloudCommerce.Core.Domain.Customers;
using cloudCommerce.Services.Authentication.External;
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
    public class ExternalAuthenticationController : AdminControllerBase
	{
		#region Fields

        private readonly IOpenAuthenticationService _openAuthenticationService;
        private readonly ExternalAuthenticationSettings _externalAuthenticationSettings;
        private readonly ISettingService _settingService;
        private readonly IPermissionService _permissionService;
		private readonly PluginMediator _pluginMediator;

		#endregion

		#region Constructors

        public ExternalAuthenticationController(
			IOpenAuthenticationService openAuthenticationService, 
            ExternalAuthenticationSettings externalAuthenticationSettings,
            ISettingService settingService, 
			IPermissionService permissionService,
			PluginMediator pluginMediator)
		{
            this._openAuthenticationService = openAuthenticationService;
            this._externalAuthenticationSettings = externalAuthenticationSettings;
            this._settingService = settingService;
            this._permissionService = permissionService;
			this._pluginMediator = pluginMediator;
		}

		#endregion 

        #region Methods

        public ActionResult Providers()
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageExternalAuthenticationMethods))
                return AccessDeniedView();

            var methodsModel = new List<AuthenticationMethodModel>();
            var methods = _openAuthenticationService.LoadAllExternalAuthenticationMethods();
            foreach (var method in methods)
            {
				var model = _pluginMediator.ToProviderModel<IExternalAuthenticationMethod, AuthenticationMethodModel>(method);
				model.IsActive = method.IsMethodActive(_externalAuthenticationSettings);
				methodsModel.Add(model);
            }

			return View(methodsModel);
        }

		public ActionResult ActivateProvider(string systemName, bool activate)
		{
			if (!_permissionService.Authorize(StandardPermissionProvider.ManageExternalAuthenticationMethods))
				return AccessDeniedView();

			var method = _openAuthenticationService.LoadExternalAuthenticationMethodBySystemName(systemName);
			bool dirty = method.IsMethodActive(_externalAuthenticationSettings) != activate;
			if (dirty)
			{
				if (!activate)
					_externalAuthenticationSettings.ActiveAuthenticationMethodSystemNames.Remove(method.Metadata.SystemName);
				else
					_externalAuthenticationSettings.ActiveAuthenticationMethodSystemNames.Add(method.Metadata.SystemName);

				_settingService.SaveSetting(_externalAuthenticationSettings);
				_pluginMediator.ActivateDependentWidgets(method.Metadata, activate);
			}

			return RedirectToAction("Providers");
		}

        #endregion
    }
}
