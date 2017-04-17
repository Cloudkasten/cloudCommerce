using System.Web.Mvc;
using System.Web.Routing;
using cloudCommerce.Web.Framework;
using cloudCommerce.Web.Framework.Plugins;

namespace cloudCommerce.Admin.Models.Tax
{
    public class TaxProviderModel : ProviderModel
    {
        [SmartResourceDisplayName("Admin.Configuration.Tax.Providers.Fields.IsPrimaryTaxProvider")]
        public bool IsPrimaryTaxProvider { get; set; }
    }
}