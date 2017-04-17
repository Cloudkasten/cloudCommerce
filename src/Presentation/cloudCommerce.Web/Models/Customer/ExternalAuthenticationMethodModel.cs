using System.Web.Routing;
using cloudCommerce.Web.Framework.Modelling;

namespace cloudCommerce.Web.Models.Customer
{
    public partial class ExternalAuthenticationMethodModel : ModelBase
    {
        public string ActionName { get; set; }
        public string ControllerName { get; set; }
        public RouteValueDictionary RouteValues { get; set; }
    }
}