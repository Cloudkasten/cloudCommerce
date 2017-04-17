using cloudCommerce.Core.Infrastructure;
using cloudCommerce.AmazonPay.Services;
using cloudCommerce.Services.Tasks;

namespace cloudCommerce.AmazonPay
{
    public class DataPollingTask : ITask
    {
		private readonly IAmazonPayService _apiService;

		public DataPollingTask(IAmazonPayService apiService)
		{
			_apiService = apiService;
		}
		
		public void Execute(TaskExecutionContext ctx)
        {
			_apiService.DataPollingTaskProcess();
        }
    }
}