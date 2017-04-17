using System.Collections.Generic;
using System.Web.Mvc;
using FluentValidation.Attributes;
using cloudCommerce.Admin.Validators.Directory;
using cloudCommerce.Web.Framework;
using cloudCommerce.Web.Framework.Localization;
using cloudCommerce.Web.Framework.Modelling;

namespace cloudCommerce.Admin.Models.Directory
{
    [Validator(typeof(StateProvinceValidator))]
    public class StateProvinceModel : EntityModelBase, ILocalizedModel<StateProvinceLocalizedModel>
    {
        public StateProvinceModel()
        {
            Locales = new List<StateProvinceLocalizedModel>();
        }
        public int CountryId { get; set; }

        [SmartResourceDisplayName("Admin.Configuration.Countries.States.Fields.Name")]
        [AllowHtml]
        public string Name { get; set; }

        [SmartResourceDisplayName("Admin.Configuration.Countries.States.Fields.Abbreviation")]
        [AllowHtml]
        public string Abbreviation { get; set; }

        [SmartResourceDisplayName("Admin.Configuration.Countries.States.Fields.Published")]
        public bool Published { get; set; }

        [SmartResourceDisplayName("Admin.Configuration.Countries.States.Fields.DisplayOrder")]
        //we don't name it "DisplayOrder" because Telerik has a small bug 
        //"if we have one more editor with the same name on a page, it doesn't allow editing"
        //in our case it's state.DisplayOrder
        public int DisplayOrder1 { get; set; }

        public IList<StateProvinceLocalizedModel> Locales { get; set; }
    }

    public class StateProvinceLocalizedModel : ILocalizedModelLocal
    {
        public int LanguageId { get; set; }
        
        [SmartResourceDisplayName("Admin.Configuration.Countries.States.Fields.Name")]
        [AllowHtml]
        public string Name { get; set; }
    }
}