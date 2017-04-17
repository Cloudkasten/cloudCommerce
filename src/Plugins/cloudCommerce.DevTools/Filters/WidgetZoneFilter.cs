using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using cloudCommerce.Core.Logging;
using cloudCommerce.Core.Localization;
using cloudCommerce.DevTools.Services;
using cloudCommerce.Core;
using cloudCommerce.Services;
using cloudCommerce.Services.Customers;
using cloudCommerce.Web.Framework.UI;
using cloudCommerce.Utilities;
using System.IO;

namespace cloudCommerce.DevTools.Filters
{
	public class WidgetZoneFilter : IActionFilter, IResultFilter
	{
		private readonly ICommonServices _services;
		private readonly Lazy<IWidgetProvider> _widgetProvider;
		private readonly ProfilerSettings _profilerSettings;

        public WidgetZoneFilter(
			ICommonServices services, 
			Lazy<IWidgetProvider> widgetProvider, 
			ProfilerSettings profilerSettings)
		{
			this._services = services;
			this._widgetProvider = widgetProvider;
			this._profilerSettings = profilerSettings;
		}

		public void OnActionExecuting(ActionExecutingContext filterContext)
		{
			if (!_profilerSettings.DisplayWidgetZones)
				return;
		}

		public void OnActionExecuted(ActionExecutedContext filterContext)
		{
            if (!_profilerSettings.DisplayWidgetZones)
                return;
		}

		public void OnResultExecuting(ResultExecutingContext filterContext)
		{
            if (!_profilerSettings.DisplayWidgetZones)
                return;
			
			// should only run on a full view rendering result
			var result = filterContext.Result as ViewResultBase;
			if (result == null)
			{
				return;
			}

			if (!this.ShouldRender(filterContext.HttpContext))
			{
				return;
			}

			if (!filterContext.IsChildAction)
			{
				_widgetProvider.Value.RegisterAction(
					new Wildcard("*"),
                    "WidgetZone",
					"DevTools",
					new { area = "cloudCommerce.DevTools" });
			}

			var viewName = result.ViewName;

			if (viewName.IsEmpty())
			{
				string action = (filterContext.RouteData.Values["action"] as string).EmptyNull();
				viewName = action;

                if (action == "WidgetsByZone")
                {
                    var model = result.Model as WidgetZoneModel;
                    
                    filterContext.Result = new ViewResult
                    {
                        ViewName = "~/Plugins/cloudCommerce.DevTools/Views/DevTools/WidgetZone.cshtml",
                    };
                    filterContext.RouteData.Values.Add("widgetZone", model.WidgetZone);
                }
			}
		}

		public void OnResultExecuted(ResultExecutedContext filterContext)
		{
            if (!_profilerSettings.DisplayWidgetZones)
                return;

			// should only run on a full view rendering result
			if (!(filterContext.Result is ViewResultBase))
			{
				return;
			}

			if (!this.ShouldRender(filterContext.HttpContext))
			{
				return;
			} 
		}

		private bool ShouldRender(HttpContextBase ctx)
		{
			if (!_services.WorkContext.CurrentCustomer.IsAdmin())
			{
				return ctx.Request.IsLocal;
			}

			return true;
		}

	}
}
