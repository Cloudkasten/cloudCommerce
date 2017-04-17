using cloudCommerce;
using System.Web.Routing;
using cloudCommerce.Core.Plugins;

namespace cloudCommerce.Services.Tax
{
	[SystemName("Tax.Free")]
	[FriendlyName("Free tax rate provider")]
	[DisplayOrder(0)]
    public class FreeTaxProvider : ITaxProvider
    {
        
		public CalculateTaxResult GetTaxRate(CalculateTaxRequest calculateTaxRequest)
        {
            var result = new CalculateTaxResult()
            {
                 TaxRate = decimal.Zero
            };
            return result;
        }

    }
}
