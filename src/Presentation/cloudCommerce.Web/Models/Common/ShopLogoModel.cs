using cloudCommerce.Web.Framework.Modelling;

namespace cloudCommerce.Web.Models.Common
{
    public partial class FaviconModel : ModelBase
    {
        public bool Uploaded { get; set; }
        public string FaviconUrl { get; set; }
    }
}