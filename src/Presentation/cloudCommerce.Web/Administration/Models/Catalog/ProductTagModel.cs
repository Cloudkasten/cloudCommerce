using System.Collections.Generic;
using System.Web.Mvc;
using FluentValidation.Attributes;
using cloudCommerce.Admin.Validators.Catalog;
using cloudCommerce.Web.Framework;
using cloudCommerce.Web.Framework.Localization;
using cloudCommerce.Web.Framework.Modelling;

namespace cloudCommerce.Admin.Models.Catalog
{
    [Validator(typeof(ProductTagValidator))]
    public class ProductTagModel : EntityModelBase, ILocalizedModel<ProductTagLocalizedModel>
    {
        public ProductTagModel()
        {
            Locales = new List<ProductTagLocalizedModel>();
        }
        [SmartResourceDisplayName("Admin.Catalog.ProductTags.Fields.Name")]
        [AllowHtml]
        public string Name { get; set; }

        [SmartResourceDisplayName("Admin.Catalog.ProductTags.Fields.ProductCount")]
        public int ProductCount { get; set; }

        public IList<ProductTagLocalizedModel> Locales { get; set; }
    }

    public class ProductTagLocalizedModel : ILocalizedModelLocal
    {
        public int LanguageId { get; set; }

        [SmartResourceDisplayName("Admin.Catalog.ProductTags.Fields.Name")]
        [AllowHtml]
        public string Name { get; set; }
    }
}