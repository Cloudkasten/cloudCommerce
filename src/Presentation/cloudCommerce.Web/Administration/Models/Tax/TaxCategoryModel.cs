using System.Web.Mvc;
using FluentValidation.Attributes;
using cloudCommerce.Admin.Validators.Tax;
using cloudCommerce.Web.Framework;
using cloudCommerce.Web.Framework.Modelling;

namespace cloudCommerce.Admin.Models.Tax
{
    [Validator(typeof(TaxCategoryValidator))]
    public class TaxCategoryModel : EntityModelBase
    {
        [SmartResourceDisplayName("Admin.Configuration.Tax.Categories.Fields.Name")]
        [AllowHtml]
        public string Name { get; set; }

        [SmartResourceDisplayName("Admin.Configuration.Tax.Categories.Fields.DisplayOrder")]
        public int DisplayOrder { get; set; }
    }
}