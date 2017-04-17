using System.Collections.Generic;
using cloudCommerce.Web.Framework.Modelling;

namespace cloudCommerce.Web.Models.Catalog
{
    public partial class RecentlyAddedProductsModel : ModelBase
    {
        public RecentlyAddedProductsModel()
        {
            Products = new List<ProductOverviewModel>();
            PagingFilteringContext = new CatalogPagingFilteringModel();
        }

        public CatalogPagingFilteringModel PagingFilteringContext { get; set; }

        public IList<ProductOverviewModel> Products { get; set; }
    }
}