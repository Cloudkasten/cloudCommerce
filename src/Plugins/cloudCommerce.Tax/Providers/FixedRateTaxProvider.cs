using System.Web.Routing;
using cloudCommerce.Core.Plugins;
using cloudCommerce.Services.Configuration;
using cloudCommerce.Services.Localization;
using cloudCommerce.Services.Tax;

namespace cloudCommerce.Tax
{
	[SystemName("Tax.FixedRate")]
	[FriendlyName("Fixed Tax Rate")]
	[DisplayOrder(5)]
	public class FixedRateTaxProvider : ITaxProvider, IConfigurable
    {
        private readonly ISettingService _settingService;
        private readonly ILocalizationService _localizationService;

        public FixedRateTaxProvider(ISettingService settingService, ILocalizationService localizationService)
        {
            this._settingService = settingService;
            _localizationService = localizationService;
        }
        
        public CalculateTaxResult GetTaxRate(CalculateTaxRequest calculateTaxRequest)
        {
            var result = new CalculateTaxResult()
            {
                TaxRate = GetTaxRate(calculateTaxRequest.TaxCategoryId)
            };
            return result;
        }

        protected decimal GetTaxRate(int taxCategoryId)
        {
            decimal rate = this._settingService.GetSettingByKey<decimal>(string.Format("Tax.TaxProvider.FixedRate.TaxCategoryId{0}", taxCategoryId));
            return rate;
        }
        
        public void GetConfigurationRoute(out string actionName, out string controllerName, out RouteValueDictionary routeValues)
        {
            actionName = "Configure";
            controllerName = "TaxFixedRate";
			routeValues = new RouteValueDictionary() { { "area", "cloudCommerce.Tax" } };
        }

    }
}
