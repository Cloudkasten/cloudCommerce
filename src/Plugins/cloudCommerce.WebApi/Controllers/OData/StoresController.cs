using System.Web.Http;
using cloudCommerce.Core.Domain.Stores;
using cloudCommerce.Services.Stores;
using cloudCommerce.Web.Framework.WebApi;
using cloudCommerce.Web.Framework.WebApi.OData;
using cloudCommerce.Web.Framework.WebApi.Security;

namespace cloudCommerce.WebApi.Controllers.OData
{
	[WebApiAuthenticate(Permission = "ManageStores")]
	public class StoresController : WebApiEntityController<Store, IStoreService>
	{
		protected override void Insert(Store entity)
		{
			Service.InsertStore(entity);
		}
		protected override void Update(Store entity)
		{
			Service.UpdateStore(entity);
		}
		protected override void Delete(Store entity)
		{
			Service.DeleteStore(entity);
		}

		[WebApiQueryable]
		public SingleResult<Store> GetStore(int key)
		{
			return GetSingleResult(key);
		}
	}
}
