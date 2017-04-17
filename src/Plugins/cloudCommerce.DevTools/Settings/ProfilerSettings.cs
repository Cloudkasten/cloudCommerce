using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using cloudCommerce.Core.Configuration;

namespace cloudCommerce.DevTools
{
	public class ProfilerSettings : ISettings
	{
		public bool EnableMiniProfilerInPublicStore { get; set; }

        public bool DisplayWidgetZones { get; set; }

	}
}