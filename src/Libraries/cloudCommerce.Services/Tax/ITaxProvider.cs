using System.Web.Routing;
using cloudCommerce.Core.Plugins;

namespace cloudCommerce.Services.Tax
{
    /// <summary>
    /// Provides an interface for creating tax providers
    /// </summary>
    public partial interface ITaxProvider : IProvider
    {
        /// <summary>
        /// Gets tax rate
        /// </summary>
        /// <param name="calculateTaxRequest">Tax calculation request</param>
        /// <returns>Tax</returns>
        CalculateTaxResult GetTaxRate(CalculateTaxRequest calculateTaxRequest);
    }
}
