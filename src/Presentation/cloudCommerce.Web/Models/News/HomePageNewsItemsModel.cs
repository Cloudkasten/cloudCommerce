using System;
using System.Collections.Generic;
using cloudCommerce.Web.Framework.Modelling;

namespace cloudCommerce.Web.Models.News
{
    public partial class HomePageNewsItemsModel : ModelBase, ICloneable
    {
        public HomePageNewsItemsModel()
        {
            NewsItems = new List<NewsItemModel>();
        }

        public int WorkingLanguageId { get; set; }
        public IList<NewsItemModel> NewsItems { get; set; }

        public object Clone()
        {
            //we use a shallow copy (deep clone is not required here)
            return this.MemberwiseClone();
        }
    }
}