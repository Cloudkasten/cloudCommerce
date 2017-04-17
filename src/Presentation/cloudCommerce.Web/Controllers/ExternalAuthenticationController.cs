using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Routing;
using cloudCommerce.Services.Authentication.External;
using cloudCommerce.Web.Models.Customer;
using cloudCommerce.Web.Framework.Controllers;
using cloudCommerce.Core;

namespace cloudCommerce.Web.Controllers
{

    public partial class ExternalAuthenticationController : PublicControllerBase
    {
		#region Fields

        private readonly IOpenAuthenticationService _openAuthenticationService;
		private readonly IStoreContext _storeContext;

        #endregion

		#region Constructors

        public ExternalAuthenticationController(IOpenAuthenticationService openAuthenticationService,
			IStoreContext storeContext)
        {
            this._openAuthenticationService = openAuthenticationService;
			this._storeContext = storeContext;
        }

        #endregion

        #region Methods

        public ActionResult RemoveParameterAssociation(string returnUrl)
        {
            ExternalAuthorizerHelper.RemoveParameters();
            return RedirectToReferrer(returnUrl);
        }

        [ChildActionOnly]
        public ActionResult ExternalMethods()
        {
            //model
            var model = new List<ExternalAuthenticationMethodModel>();

			foreach (var eam in _openAuthenticationService.LoadActiveExternalAuthenticationMethods(_storeContext.CurrentStore.Id))
            {
                var eamModel = new ExternalAuthenticationMethodModel();

                string actionName;
                string controllerName;
                RouteValueDictionary routeValues;
                eam.Value.GetPublicInfoRoute(out actionName, out controllerName, out routeValues);
                eamModel.ActionName = actionName;
                eamModel.ControllerName = controllerName;
                eamModel.RouteValues = routeValues;

                model.Add(eamModel);
            }

            return PartialView(model);
        }

        #endregion
    }
}
