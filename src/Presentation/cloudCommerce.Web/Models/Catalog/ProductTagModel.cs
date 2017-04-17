using cloudCommerce.Web.Framework.Modelling;

namespace cloudCommerce.Web.Models.Catalog
{
    public partial class ProductTagModel : EntityModelBase
    {
        public string Name { get; set; }

        public string SeName { get; set; }

        public int ProductCount { get; set; }
    }
}