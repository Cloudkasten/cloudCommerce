using cloudCommerce.Core;
using cloudCommerce.Web.Framework;
﻿using cloudCommerce.Web.Framework.Plugins;

namespace cloudCommerce.Admin.Models.Cms
{
	public class WidgetModel : ProviderModel, IActivatable
    {
		[SmartResourceDisplayName("Common.IsActive")]
        public bool IsActive { get; set; }

    }
}