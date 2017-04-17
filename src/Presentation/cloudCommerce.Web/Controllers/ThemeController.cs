using System.Web.Mvc;
using cloudCommerce.Core;
using cloudCommerce.Core.Themes;
using cloudCommerce.Services.Themes;
using cloudCommerce.Web.Framework.Controllers;
using cloudCommerce.Web.Framework.Security;
using cloudCommerce.Web.Framework.Theming;

namespace cloudCommerce.Web.Controllers
{
	[AdminAuthorize]
    public partial class ThemeController : PublicControllerBase
	{
		#region Fields

        private readonly IThemeRegistry _themeRegistry;
        private readonly IThemeVariablesService _themeVarService;
		private readonly IThemeContext _themeContext;
		private readonly IStoreContext _storeContext;

	    #endregion

		#region Constructors

        public ThemeController(
			IThemeRegistry themeRegistry, 
			IThemeVariablesService themeVarService,
			IThemeContext themeContext,
			IStoreContext storeContext)
		{
            this._themeRegistry = themeRegistry;
            this._themeVarService = themeVarService;
			this._themeContext = themeContext;
			this._storeContext = storeContext;
		}

		#endregion 

        #region Methods

        [ChildActionOnly]
        public ActionResult ConfigureTheme(string theme, int storeId)
        {
            if (theme.HasValue())
            {
				_themeContext.SetRequestTheme(theme);
            }

			if (storeId > 0)
			{
				_storeContext.SetRequestStore(storeId);
			}

            var model = TempData["OverriddenThemeVars"] ?? _themeVarService.GetThemeVariables(theme, storeId);

            return View(model);
        }

        #endregion
    }
}
