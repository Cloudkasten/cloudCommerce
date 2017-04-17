using System.Web.Mvc;
using System.Web.Routing;
using cloudCommerce.Core;
using cloudCommerce.Web.Framework;
using cloudCommerce.Web.Framework.Plugins;

namespace cloudCommerce.Admin.Models.ExternalAuthentication
{
	public class AuthenticationMethodModel : ProviderModel, IActivatable
    {
        [SmartResourceDisplayName("Admin.Configuration.ExternalAuthenticationMethods.Fields.IsActive")]
        public bool IsActive { get; set; }
    }
}