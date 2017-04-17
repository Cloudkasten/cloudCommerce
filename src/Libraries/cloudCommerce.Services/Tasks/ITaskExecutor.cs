using System;
using System.Collections.Generic;
using cloudCommerce.Core.Domain.Tasks;

namespace cloudCommerce.Services.Tasks
{
    public interface ITaskExecutor
    {
        void Execute(
			ScheduleTask task, 
			IDictionary<string, string> taskParameters = null, 
			bool throwOnError = false);
    }
}
