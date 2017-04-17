using System;
using System.Linq;
using System.Web.Mvc;
using cloudCommerce.Admin.Models.Customers;
using cloudCommerce.Core.Domain.Common;
using cloudCommerce.Core.Domain.Customers;
using cloudCommerce.Services.Common;
using cloudCommerce.Services.Customers;
using cloudCommerce.Services.Directory;
using cloudCommerce.Services.Helpers;
using cloudCommerce.Services.Localization;
using cloudCommerce.Services.Security;
using cloudCommerce.Web.Framework.Controllers;
using cloudCommerce.Web.Framework.Security;
using Telerik.Web.Mvc;

namespace cloudCommerce.Admin.Controllers
{
    [AdminAuthorize]
    public class OnlineCustomerController : AdminControllerBase
    {
        #region Fields

        private readonly ICustomerService _customerService;
        private readonly IGeoCountryLookup _geoCountryLookup;
        private readonly IDateTimeHelper _dateTimeHelper;
        private readonly CustomerSettings _customerSettings;
        private readonly AdminAreaSettings _adminAreaSettings;
        private readonly IPermissionService _permissionService;
        private readonly ILocalizationService _localizationService;

        #endregion

        #region Constructors

        public OnlineCustomerController(ICustomerService customerService,
            IGeoCountryLookup geoCountryLookup, IDateTimeHelper dateTimeHelper,
            CustomerSettings customerSettings, AdminAreaSettings adminAreaSettings,
            IPermissionService permissionService, ILocalizationService localizationService)
        {
            this._customerService = customerService;
            this._geoCountryLookup = geoCountryLookup;
            this._dateTimeHelper = dateTimeHelper;
            this._customerSettings = customerSettings;
            this._adminAreaSettings = adminAreaSettings;
            this._permissionService = permissionService;
            this._localizationService = localizationService;
        }

        #endregion
        
        #region Online customers

        public ActionResult List()
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageCustomers))
                return AccessDeniedView();

            var customers = _customerService.GetOnlineCustomers(DateTime.UtcNow.AddMinutes(-_customerSettings.OnlineCustomerMinutes),
                null, 0, _adminAreaSettings.GridPageSize);

            var model = new GridModel<OnlineCustomerModel>
            {
                Data = customers.Select(x =>
                {
                    return new OnlineCustomerModel()
                    {
                        Id = x.Id,
                        CustomerInfo = x.IsRegistered() ? x.Email : _localizationService.GetResource("Admin.Customers.Guest"),
                        LastIpAddress = x.LastIpAddress,
                        Location = _geoCountryLookup.LookupCountryName(x.LastIpAddress),
                        LastActivityDate = _dateTimeHelper.ConvertToUserTime(x.LastActivityDateUtc, DateTimeKind.Utc),
                        LastVisitedPage = x.GetAttribute<string>(SystemCustomerAttributeNames.LastVisitedPage)
                    };
                }),
                Total = customers.TotalCount
            };
            return View(model);
        }

        [HttpPost, GridAction(EnableCustomBinding = true)]
        public ActionResult List(GridCommand command)
        {
			var model = new GridModel<OnlineCustomerModel>();

			if (_permissionService.Authorize(StandardPermissionProvider.ManageCustomers))
			{
				var lastActivityFrom = DateTime.UtcNow.AddMinutes(-_customerSettings.OnlineCustomerMinutes);
				var customers = _customerService.GetOnlineCustomers(lastActivityFrom, null, command.Page - 1, command.PageSize);

				model.Data = customers.Select(x =>
				{
					return new OnlineCustomerModel
					{
						Id = x.Id,
						CustomerInfo = x.IsRegistered() ? x.Email : T("Admin.Customers.Guest").Text,
						LastIpAddress = x.LastIpAddress,
						Location = _geoCountryLookup.LookupCountryName(x.LastIpAddress),
						LastActivityDate = _dateTimeHelper.ConvertToUserTime(x.LastActivityDateUtc, DateTimeKind.Utc),
						LastVisitedPage = x.GetAttribute<string>(SystemCustomerAttributeNames.LastVisitedPage)
					};
				});

				model.Total = customers.TotalCount;
			}
			else
			{
				model.Data = Enumerable.Empty<OnlineCustomerModel>();

				NotifyAccessDenied();
			}

            return new JsonResult
            {
                Data = model
            };
        }

        #endregion
    }
}
