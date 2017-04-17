using System.Web.Http;
using cloudCommerce.Core.Domain.Seo;
using cloudCommerce.Services.Seo;
using cloudCommerce.Web.Framework.WebApi;
using cloudCommerce.Web.Framework.WebApi.OData;
using cloudCommerce.Web.Framework.WebApi.Security;

namespace cloudCommerce.WebApi.Controllers.OData
{
	[WebApiAuthenticate(Permission = "ManageMaintenance")]
	public class UrlRecordsController : WebApiEntityController<UrlRecord, IUrlRecordService>
	{
		protected override void Insert(UrlRecord entity)
		{
			throw this.ExceptionForbidden();
		}
		protected override void Update(UrlRecord entity)
		{
			throw this.ExceptionForbidden();
		}
		protected override void Delete(UrlRecord entity)
		{
			throw this.ExceptionForbidden();
		}

		[WebApiQueryable]
		public SingleResult<UrlRecord> GetUrlRecord(int key)
		{
			return GetSingleResult(key);
		}
	}
}
