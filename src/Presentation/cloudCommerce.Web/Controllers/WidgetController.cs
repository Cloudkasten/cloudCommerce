using System;
using System.Collections.Generic;
using System.Web.Mvc;
using cloudCommerce.Web.Framework.Controllers;
using cloudCommerce.Web.Framework.UI;

namespace cloudCommerce.Web.Controllers
{
    public partial class WidgetController : PublicControllerBase
    {
        [ChildActionOnly]
        public ActionResult WidgetsByZone(WidgetZoneModel zoneModel)
        {
			return PartialView(zoneModel);
        }

        [ChildActionOnly]
        public ActionResult TabWidgets(object model, string viewDataKey)
        {
            var widgets = this.ControllerContext.ParentActionViewContext.ViewData[viewDataKey];
            return PartialView(widgets);
        }
    }
}
