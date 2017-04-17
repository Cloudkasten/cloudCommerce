using System;
using System.Collections.Generic;
using System.Globalization;
using cloudCommerce.Data.Setup;

namespace cloudCommerce.Web.Infrastructure.Installation
{
    /// <summary>
    /// Localization service for installation process
    /// </summary>
    public partial interface IInstallationLocalizationService
    {
        string GetResource(string resourceName);

        InstallationLanguage GetCurrentLanguage();

        void SaveCurrentLanguage(string languageCode);

        IList<InstallationLanguage> GetAvailableLanguages();

        IEnumerable<InstallationAppLanguageMetadata> GetAvailableAppLanguages();
        Lazy<InvariantSeedData, InstallationAppLanguageMetadata> GetAppLanguage(string culture);
    }
}
