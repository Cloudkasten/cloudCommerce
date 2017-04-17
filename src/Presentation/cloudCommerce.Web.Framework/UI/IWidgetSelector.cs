using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cloudCommerce.Web.Framework.UI
{
    public interface IWidgetSelector
    {
		IEnumerable<WidgetRouteInfo> GetWidgets(string widgetZone, object model);
    }
}
