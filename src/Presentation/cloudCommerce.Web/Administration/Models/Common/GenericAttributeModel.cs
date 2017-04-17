using System.Web.Mvc;
using FluentValidation.Attributes;
using cloudCommerce.Admin.Validators.Localization;
using cloudCommerce.Web.Framework;
using cloudCommerce.Web.Framework.Modelling;

namespace cloudCommerce.Admin.Models.Common
{
    [Validator(typeof(GenericAttributeValidator))]
    public partial class GenericAttributeModel : EntityModelBase
    {
        [SmartResourceDisplayName("Admin.Common.GenericAttributes.Fields.Name")]
        public string Key { get; set; }

        [AllowHtml]
        [SmartResourceDisplayName("Admin.Common.GenericAttributes.Fields.Value")]
        public string Value { get; set; }

        public string EntityName { get; set; }

        public int EntityId { get; set; }
    }
}