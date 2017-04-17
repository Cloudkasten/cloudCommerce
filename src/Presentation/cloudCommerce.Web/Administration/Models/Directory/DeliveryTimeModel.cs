using System;
using System.Collections.Generic;
using System.Web.Mvc;
using FluentValidation.Attributes;
using cloudCommerce.Admin.Validators.Directory;
using cloudCommerce.Web.Framework;
using cloudCommerce.Web.Framework.Localization;
using cloudCommerce.Web.Framework.Modelling;

namespace cloudCommerce.Admin.Models.Directory
{
    [Validator(typeof(DeliveryTimeValidator))]
    public class DeliveryTimeModel : EntityModelBase, ILocalizedModel<DeliveryTimeLocalizedModel>
    {
        public DeliveryTimeModel()
        {
            Locales = new List<DeliveryTimeLocalizedModel>();
        }

        [SmartResourceDisplayName("Admin.Configuration.DeliveryTimes.Fields.Name")]
        [AllowHtml]
        public string Name { get; set; }

        [SmartResourceDisplayName("Admin.Configuration.DeliveryTimes.Fields.DisplayLocale")]
        [AllowHtml]
        public string DisplayLocale { get; set; }

        [SmartResourceDisplayName("Admin.Configuration.DeliveryTimes.Fields.Color")]
        [AllowHtml]
        public string ColorHexValue { get; set; }

        [SmartResourceDisplayName("Admin.Configuration.DeliveryTimes.Fields.DisplayOrder")]
        public int DisplayOrder { get; set; }

        public IList<DeliveryTimeLocalizedModel> Locales { get; set; }
    }

    public class DeliveryTimeLocalizedModel : ILocalizedModelLocal
    {
        public int LanguageId { get; set; }

        [SmartResourceDisplayName("Admin.Configuration.DeliveryTimes.Fields.Name")]
        [AllowHtml]
        public string Name { get; set; }
    }
}