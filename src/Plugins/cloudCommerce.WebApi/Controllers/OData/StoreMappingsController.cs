using System.Web.Http;
using cloudCommerce.Core.Domain.Stores;
using cloudCommerce.Services.Stores;
using cloudCommerce.Web.Framework.WebApi;
using cloudCommerce.Web.Framework.WebApi.OData;
using cloudCommerce.Web.Framework.WebApi.Security;

namespace cloudCommerce.WebApi.Controllers.OData
{
	[WebApiAuthenticate(Permission = "ManageStores")]
	public class StoreMappingsController : WebApiEntityController<StoreMapping, IStoreMappingService>
	{
		protected override void Insert(StoreMapping entity)
		{
			Service.InsertStoreMapping(entity);
		}
		protected override void Update(StoreMapping entity)
		{
			Service.UpdateStoreMapping(entity);
		}
		protected override void Delete(StoreMapping entity)
		{
			Service.DeleteStoreMapping(entity);
		}

		[WebApiQueryable]
		public SingleResult<StoreMapping> GetStoreMapping(int key)
		{
			return GetSingleResult(key);
		}
	}
}
