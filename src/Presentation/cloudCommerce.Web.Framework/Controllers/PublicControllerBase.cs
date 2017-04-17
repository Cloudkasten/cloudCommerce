using cloudCommerce.Web.Framework.Controllers;
using cloudCommerce.Web.Framework.Filters;
using cloudCommerce.Web.Framework.Localization;
using cloudCommerce.Web.Framework.Security;
using cloudCommerce.Web.Framework.Seo;

namespace cloudCommerce.Web.Framework.Controllers
{

    [CustomerLastActivity]
    [StoreIpAddress]
    [StoreLastVisitedPage]
    [CheckAffiliate]
    [StoreClosed]
    [PublicStoreAllowNavigation]
    [LanguageSeoCode]
    [RequireHttpsByConfigAttribute(SslRequirement.Retain)]
	[CanonicalHostName]
    public abstract partial class PublicControllerBase : SmartController
    {
    }
}
