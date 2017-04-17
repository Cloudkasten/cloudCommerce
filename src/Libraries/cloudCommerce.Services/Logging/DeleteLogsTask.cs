using System;
using cloudCommerce.Core.Domain.Logging;
using cloudCommerce.Core.Logging;
using cloudCommerce.Services.Tasks;

namespace cloudCommerce.Services.Logging
{
    /// <summary>
    /// Represents a task for deleting log entries
    /// </summary>
    public partial class DeleteLogsTask : ITask
    {
        private readonly ILogger _logger;

        public DeleteLogsTask(ILogger logger)
        {
            this._logger = logger;
        }

        /// <summary>
        /// Executes a task
        /// </summary>
		public void Execute(TaskExecutionContext ctx)
        {
            var olderThanDays = 7; // TODO: move to settings
            var toUtc = DateTime.UtcNow.AddDays(-olderThanDays);

			_logger.ClearLog(toUtc, LogLevel.Error);
        }
    }
}
