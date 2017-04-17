using System.Collections.Generic;
using System.Web.Mvc;
using cloudCommerce.Web.Framework;

namespace cloudCommerce.DiscountRules.Models
{
	public class ShippingCountryModel : DiscountRuleModelBase
    {
		public ShippingCountryModel()
        {
			AvailableCountries = new List<SelectListItem>();
        }
		[SmartResourceDisplayName("Plugins.DiscountRules.ShippingCountry.Fields.Country")]
		public int CountryId { get; set; }
		public IList<SelectListItem> AvailableCountries { get; set; }
    }
}