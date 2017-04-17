using System.Web.Http;
using cloudCommerce.Core.Domain.Media;
using cloudCommerce.Services.Media;
using cloudCommerce.Web.Framework.WebApi;
using cloudCommerce.Web.Framework.WebApi.OData;
using cloudCommerce.Web.Framework.WebApi.Security;

namespace cloudCommerce.WebApi.Controllers.OData
{
	[WebApiAuthenticate(Permission = "ManageCatalog")]
	public class DownloadsController : WebApiEntityController<Download, IDownloadService>
	{
		protected override void Insert(Download entity)
		{
			Service.InsertDownload(entity);
		}
		protected override void Update(Download entity)
		{
			Service.UpdateDownload(entity);
		}
		protected override void Delete(Download entity)
		{
			Service.DeleteDownload(entity);
		}

		[WebApiQueryable]
		public SingleResult<Download> GetDownload(int key)
		{
			return GetSingleResult(key);
		}
	}
}
