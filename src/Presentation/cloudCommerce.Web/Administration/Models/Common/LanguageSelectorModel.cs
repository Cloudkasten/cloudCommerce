using System.Collections.Generic;
using cloudCommerce.Admin.Models.Localization;
using cloudCommerce.Web.Framework.Modelling;

namespace cloudCommerce.Admin.Models.Common
{
    public class LanguageSelectorModel : ModelBase
    {
        public LanguageSelectorModel()
        {
            AvailableLanguages = new List<LanguageModel>();
        }

        public IList<LanguageModel> AvailableLanguages { get; set; }

        public LanguageModel CurrentLanguage { get; set; }
    }
}