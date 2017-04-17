using cloudCommerce.Core.Configuration;

namespace cloudCommerce.Core.Domain.Directory
{
    public class CurrencySettings : ISettings
    {
        public string ActiveExchangeRateProviderSystemName { get; set; }
        public bool AutoUpdateEnabled { get; set; }
        public long LastUpdateTime { get; set; }
    }
}