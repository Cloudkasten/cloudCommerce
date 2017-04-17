using System;
using cloudCommerce.Core.Caching;
using cloudCommerce.Core.Infrastructure;
using cloudCommerce.Services.Tasks;

namespace cloudCommerce.Services.Caching
{
    /// <summary>
    /// Clear cache scheduled task implementation
    /// </summary>
    public partial class ClearCacheTask : ITask
    {
		private readonly ICacheManager _cacheManager;
		
		public ClearCacheTask(Func<string, ICacheManager> cache)
		{
			_cacheManager = cache("static");
		}
		
		/// <summary>
        /// Executes a task
        /// </summary>
		public void Execute(TaskExecutionContext ctx)
        {
			_cacheManager.Clear();
        }
    }
}
