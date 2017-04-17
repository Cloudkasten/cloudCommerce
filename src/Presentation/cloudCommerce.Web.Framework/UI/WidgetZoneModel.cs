using System;
using System.Collections.Generic;
using cloudCommerce.Web.Framework.Modelling;

namespace cloudCommerce.Web.Framework.UI
{
	public class WidgetZoneModel : ModelBase
	{
		public IEnumerable<WidgetRouteInfo> Widgets { get; set; }
		public string WidgetZone { get; set; }
		public object Model { get; set; }
	}
}