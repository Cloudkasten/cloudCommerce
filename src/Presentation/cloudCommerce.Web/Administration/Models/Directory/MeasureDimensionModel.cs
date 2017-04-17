using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using FluentValidation.Attributes;
using cloudCommerce.Admin.Validators.Directory;
using cloudCommerce.Web.Framework;
using cloudCommerce.Web.Framework.Modelling;

namespace cloudCommerce.Admin.Models.Directory
{
    [Validator(typeof(MeasureDimensionValidator))]
    public class MeasureDimensionModel : EntityModelBase
    {
        [SmartResourceDisplayName("Admin.Configuration.Measures.Dimensions.Fields.Name")]
        [AllowHtml]
        public string Name { get; set; }

        [SmartResourceDisplayName("Admin.Configuration.Measures.Dimensions.Fields.SystemKeyword")]
        [AllowHtml]
        public string SystemKeyword { get; set; }

        [SmartResourceDisplayName("Admin.Configuration.Measures.Dimensions.Fields.Ratio")]
        [UIHint("Decimal8")]
        public decimal Ratio { get; set; }

        [SmartResourceDisplayName("Admin.Configuration.Measures.Dimensions.Fields.DisplayOrder")]
        public int DisplayOrder { get; set; }

        [SmartResourceDisplayName("Admin.Configuration.Measures.Dimensions.Fields.IsPrimaryWeight")]
        public bool IsPrimaryDimension { get; set; }
    }
}