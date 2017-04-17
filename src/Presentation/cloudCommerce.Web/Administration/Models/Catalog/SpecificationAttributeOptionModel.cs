using System.Collections.Generic;
using System.Web.Mvc;
using FluentValidation.Attributes;
using cloudCommerce.Admin.Validators.Catalog;
using cloudCommerce.Web.Framework;
using cloudCommerce.Web.Framework.Localization;
using cloudCommerce.Web.Framework.Modelling;

namespace cloudCommerce.Admin.Models.Catalog
{
    [Validator(typeof(SpecificationAttributeOptionValidator))]
    public class SpecificationAttributeOptionModel : EntityModelBase, ILocalizedModel<SpecificationAttributeOptionLocalizedModel>
    {
        public SpecificationAttributeOptionModel()
        {
            Locales = new List<SpecificationAttributeOptionLocalizedModel>();
        }

        public int SpecificationAttributeId { get; set; }

        [SmartResourceDisplayName("Admin.Catalog.Attributes.SpecificationAttributes.Options.Fields.Name")]
        [AllowHtml]
        public string Name { get; set; }

        [SmartResourceDisplayName("Admin.Catalog.Attributes.SpecificationAttributes.Options.Fields.DisplayOrder")]
        public int DisplayOrder {get;set;}
        
        public IList<SpecificationAttributeOptionLocalizedModel> Locales { get; set; }

		// codehint: sm-add
		[SmartResourceDisplayName("Admin.Catalog.Attributes.SpecificationAttributes.Options.Fields.Multiple")]
		public bool Multiple { get; set; }
    }

    public class SpecificationAttributeOptionLocalizedModel : ILocalizedModelLocal
    {
        public int LanguageId { get; set; }

        [SmartResourceDisplayName("Admin.Catalog.Attributes.SpecificationAttributes.Options.Fields.Name")]
        [AllowHtml]
        public string Name { get; set; }
    }
}