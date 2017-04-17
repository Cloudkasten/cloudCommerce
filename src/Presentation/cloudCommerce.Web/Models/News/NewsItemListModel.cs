using System.Collections.Generic;
using cloudCommerce.Web.Framework.Modelling;

namespace cloudCommerce.Web.Models.News
{
    public partial class NewsItemListModel : ModelBase
    {
        public NewsItemListModel()
        {
            PagingFilteringContext = new NewsPagingFilteringModel();
            NewsItems = new List<NewsItemModel>();
        }

        public int WorkingLanguageId { get; set; }
        public NewsPagingFilteringModel PagingFilteringContext { get; set; }
        public IList<NewsItemModel> NewsItems { get; set; }
    }
}