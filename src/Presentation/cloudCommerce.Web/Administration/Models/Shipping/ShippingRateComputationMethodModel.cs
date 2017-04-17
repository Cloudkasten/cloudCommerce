using System.Web.Mvc;
using System.Web.Routing;
using cloudCommerce.Core;
using cloudCommerce.Web.Framework;
using cloudCommerce.Web.Framework.Plugins;

namespace cloudCommerce.Admin.Models.Shipping
{
	public class ShippingRateComputationMethodModel : ProviderModel, IActivatable
    {
        [SmartResourceDisplayName("Common.IsActive")]
        public bool IsActive { get; set; }
    }
}