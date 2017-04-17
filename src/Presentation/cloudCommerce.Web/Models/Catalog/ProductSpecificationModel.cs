using cloudCommerce.Web.Framework.Modelling;

namespace cloudCommerce.Web.Models.Catalog
{
    public partial class ProductSpecificationModel : ModelBase
    {
        public int SpecificationAttributeId { get; set; }

        public string SpecificationAttributeName { get; set; }

        public string SpecificationAttributeOption { get; set; }
    }
}