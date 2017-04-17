using cloudCommerce.Services.Tasks;
using cloudCommerce.Utilities;

namespace cloudCommerce.Services.Common
{
	/// <summary>
	/// Task to cleanup temporary files
	/// </summary>
	public partial class TempFileCleanupTask : ITask
	{
		public void Execute(TaskExecutionContext ctx)
		{
			FileSystemHelper.TempCleanup();
		}
	}
}
