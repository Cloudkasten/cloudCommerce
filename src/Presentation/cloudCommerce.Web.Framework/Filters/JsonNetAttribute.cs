using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Security;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using cloudCommerce.Core;
using cloudCommerce.Core.Data;
using cloudCommerce.Core.Logging;
using cloudCommerce.Services.Helpers;
using cloudCommerce.Web.Framework.Modelling;

namespace cloudCommerce.Web.Framework.Filters
{
	public class JsonNetAttribute : ActionFilterAttribute
	{
		public Lazy<IDateTimeHelper> DateTimeHelper { get; set; }

		[SuppressMessage("ReSharper", "PossibleNullReferenceException")]
		public override void OnActionExecuted(ActionExecutedContext filterContext)
		{
			if (!DataSettings.DatabaseIsInstalled())
				return;

			if (filterContext == null || filterContext.HttpContext == null || filterContext.HttpContext.Request == null)
				return;

			// don't apply filter to child methods
			if (filterContext.IsChildAction)
				return;

			// handle JsonResult only
			if (filterContext.Result.GetType() != typeof(JsonResult))
				return;

	        var jsonResult = filterContext.Result as JsonResult;

			filterContext.Result = new JsonNetResult(DateTimeHelper.Value)
			{
				Data = jsonResult.Data,
				ContentType = jsonResult.ContentType,
				ContentEncoding = jsonResult.ContentEncoding,
				JsonRequestBehavior = jsonResult.JsonRequestBehavior
			};
		}
	}

}
