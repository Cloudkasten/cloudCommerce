using System.IO;
using cloudCommerce.Core.Domain;
using cloudCommerce.Core.Logging;
using cloudCommerce.Utilities;

namespace cloudCommerce.Services.DataExchange.Export.Deployment
{
	public class FileSystemFilePublisher : IFilePublisher
	{
		public virtual void Publish(ExportDeploymentContext context, ExportDeployment deployment)
		{
			var targetFolder = deployment.GetDeploymentFolder(true);

			if (!FileSystemHelper.CopyDirectory(new DirectoryInfo(context.FolderContent), new DirectoryInfo(targetFolder)))
			{
				context.Result.LastError = context.T("Admin.DataExchange.Export.Deployment.CopyFileFailed");
			}

			context.Log.Information("Copied export data files to " + targetFolder);
		}
	}
}
