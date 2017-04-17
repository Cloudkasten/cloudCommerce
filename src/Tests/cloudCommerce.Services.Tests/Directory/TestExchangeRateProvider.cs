using System.Collections.Generic;
using cloudCommerce.Core.Domain.Directory;
using cloudCommerce.Core.Plugins;
using cloudCommerce.Services.Directory;

namespace cloudCommerce.Services.Tests.Directory
{
    public class TestExchangeRateProvider : BasePlugin, IExchangeRateProvider
    {
        #region Methods

        /// <summary>
        /// Gets currency live rates
        /// </summary>
        /// <param name="exchangeRateCurrencyCode">Exchange rate currency code</param>
        /// <returns>Exchange rates</returns>
        public IList<ExchangeRate> GetCurrencyLiveRates(string exchangeRateCurrencyCode)
        {
            return new List<ExchangeRate>();
        }

        #endregion

    }
}
