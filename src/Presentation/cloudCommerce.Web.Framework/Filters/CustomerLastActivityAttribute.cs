using System;
using System.Web.Mvc;
using cloudCommerce.Core;
using cloudCommerce.Core.Data;
using cloudCommerce.Services.Customers;

namespace cloudCommerce.Web.Framework.Filters
{
    public class CustomerLastActivityAttribute : ActionFilterAttribute
    {
		public Lazy<IWorkContext> WorkContext { get; set; }
		public Lazy<ICustomerService> CustomerService { get; set; }
		
		public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!DataSettings.DatabaseIsInstalled())
                return;

            if (filterContext == null || filterContext.HttpContext == null || filterContext.HttpContext.Request == null)
                return;

            // don't apply filter to child methods
            if (filterContext.IsChildAction)
                return;

            // only GET requests
            if (!String.Equals(filterContext.HttpContext.Request.HttpMethod, "GET", StringComparison.OrdinalIgnoreCase))
                return;

            var customer = WorkContext.Value.CurrentCustomer;
            
            // update last activity date
            if (!customer.IsSystemAccount && customer.LastActivityDateUtc.AddMinutes(1.0) < DateTime.UtcNow)
            {
                customer.LastActivityDateUtc = DateTime.UtcNow;
				CustomerService.Value.UpdateCustomer(customer);
            }
        }
    }
}
