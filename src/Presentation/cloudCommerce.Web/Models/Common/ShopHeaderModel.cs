using cloudCommerce.Web.Framework.Modelling;

namespace cloudCommerce.Web.Models.Common
{
    public partial class ShopHeaderModel : ModelBase
    {
        public bool LogoUploaded { get; set; }
        public string LogoUrl { get; set; }
        public int LogoWidth { get; set; }
        public int LogoHeight { get; set; }
        public string LogoTitle { get; set; }
    }
}