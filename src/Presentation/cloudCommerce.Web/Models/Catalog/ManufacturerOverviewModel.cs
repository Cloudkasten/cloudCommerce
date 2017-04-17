using cloudCommerce.Web.Framework.Modelling;
using cloudCommerce.Web.Models.Media;

namespace cloudCommerce.Web.Models.Catalog
{
    public partial class ManufacturerOverviewModel : EntityModelBase
    {
        public ManufacturerOverviewModel()
        {
            PictureModel = new PictureModel();
        }

        public string Name { get; set; }
        public string SeName { get; set; }
        public string Description { get; set; }
        
        //picture
        public PictureModel PictureModel { get; set; }
    }
}