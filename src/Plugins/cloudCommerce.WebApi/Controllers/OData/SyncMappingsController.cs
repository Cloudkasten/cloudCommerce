using System.Web.Http;
using cloudCommerce.Core.Domain.DataExchange;
using cloudCommerce.Core.Domain.Stores;
using cloudCommerce.Services.DataExchange;
using cloudCommerce.Web.Framework.WebApi;
using cloudCommerce.Web.Framework.WebApi.OData;
using cloudCommerce.Web.Framework.WebApi.Security;

namespace cloudCommerce.WebApi.Controllers.OData
{
	[WebApiAuthenticate(Permission = "ManageMaintenance")] // TODO: ManageMaintenance... really?
	public class SyncMappingsController : WebApiEntityController<SyncMapping, ISyncMappingService>
	{
		protected override void Insert(SyncMapping entity)
		{
			Service.InsertSyncMapping(entity);
		}
		protected override void Update(SyncMapping entity)
		{
			Service.UpdateSyncMapping(entity);
		}
		protected override void Delete(SyncMapping entity)
		{
			Service.DeleteSyncMapping(entity);
		}

		[WebApiQueryable]
		public SingleResult<SyncMapping> GetSyncMapping(int key)
		{
			return GetSingleResult(key);
		}
	}
}
