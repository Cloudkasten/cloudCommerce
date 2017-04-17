using System;
using System.ComponentModel.DataAnnotations;
using cloudCommerce.Web.Framework;
using cloudCommerce.Web.Framework.Modelling;

namespace cloudCommerce.Admin.Models.Catalog
{
    public class ProductReviewListModel : ModelBase
    {
        [SmartResourceDisplayName("Admin.Catalog.ProductReviews.List.CreatedOnFrom")]
        public DateTime? CreatedOnFrom { get; set; }

        [SmartResourceDisplayName("Admin.Catalog.ProductReviews.List.CreatedOnTo")]
        public DateTime? CreatedOnTo { get; set; }
    }
}