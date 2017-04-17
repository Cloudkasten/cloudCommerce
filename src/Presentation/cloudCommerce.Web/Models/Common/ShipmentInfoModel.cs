using System.Collections.Generic;
using cloudCommerce.Web.Framework.Modelling;
using cloudCommerce.Web.Models.Catalog;
using cloudCommerce.Web.Models.Topics;

namespace cloudCommerce.Web.Models.Common
{
    public partial class ShipmentInfoModel : ModelBase
    {
        public ShipmentInfoModel()
        {
            Products = new List<ProductOverviewModel>();
            Categories = new List<CategoryModel>();
            Manufacturers = new List<ManufacturerModel>();
            Topics = new List<TopicModel>();
        }
        public IList<ProductOverviewModel> Products { get; set; }
        public IList<CategoryModel> Categories { get; set; }
        public IList<ManufacturerModel> Manufacturers { get; set; }
        public IList<TopicModel> Topics { get; set; }
    }
}