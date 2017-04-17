using System;
using System.Linq;
using System.Linq.Expressions;
using cloudCommerce.Core.Data;
using cloudCommerce.Core.Domain.Messages;
using cloudCommerce.Data;
using cloudCommerce.Services.Tasks;

namespace cloudCommerce.Services.Messages
{
    /// <summary>
    /// Represents a task for deleting sent emails from the message queue
    /// </summary>
    public partial class QueuedMessagesClearTask : ITask
    {
        private readonly IRepository<QueuedEmail> _qeRepository;

		public QueuedMessagesClearTask(IRepository<QueuedEmail> qeRepository)
        {
			this._qeRepository = qeRepository;
        }

		public void Execute(TaskExecutionContext ctx)
        {
			var olderThan = DateTime.UtcNow.AddDays(-14);
			_qeRepository.DeleteAll(x => x.SentOnUtc.HasValue && x.CreatedOnUtc < olderThan);

			_qeRepository.Context.ShrinkDatabase();
        }
    }
}
