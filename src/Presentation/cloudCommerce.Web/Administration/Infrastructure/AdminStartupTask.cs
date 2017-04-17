using cloudCommerce.ComponentModel;
using cloudCommerce.Core.Infrastructure;
using cloudCommerce.Services.DataExchange.Csv;
using cloudCommerce.Services.DataExchange.Import;

namespace cloudCommerce.Admin.Infrastructure
{
    public class AdminStartupTask : IStartupTask
    {
        public void Execute()
        {
			TypeConverterFactory.RegisterConverter<CsvConfiguration>(new CsvConfigurationConverter());
			TypeConverterFactory.RegisterConverter<ColumnMapConverter>(new ColumnMapConverter());
		}

        public int Order
        {
            get { return 100; }
        }
    }
}