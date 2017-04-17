using System.Collections.Generic;
using System.Web.Mvc;
using cloudCommerce.Web.Framework;

namespace cloudCommerce.DiscountRules.Models
{
	public class BillingCountryModel : DiscountRuleModelBase
    {
        public BillingCountryModel()
        {
			AvailableCountries = new List<SelectListItem>();
        }
		[SmartResourceDisplayName("Plugins.DiscountRules.BillingCountry.Fields.Country")]
		public int CountryId { get; set; }
		public IList<SelectListItem> AvailableCountries { get; set; }
    }
}