using System.Web.Http;
using cloudCommerce.Core.Domain.Directory;
using cloudCommerce.Services.Directory;
using cloudCommerce.Web.Framework.WebApi;
using cloudCommerce.Web.Framework.WebApi.OData;
using cloudCommerce.Web.Framework.WebApi.Security;

namespace cloudCommerce.WebApi.Controllers.OData
{
	[WebApiAuthenticate(Permission = "ManageCountries")]
	public class StateProvincesController : WebApiEntityController<StateProvince, IStateProvinceService>
	{
		protected override void Insert(StateProvince entity)
		{
			Service.InsertStateProvince(entity);
		}
		protected override void Update(StateProvince entity)
		{
			Service.UpdateStateProvince(entity);
		}
		protected override void Delete(StateProvince entity)
		{
			Service.DeleteStateProvince(entity);
		}

		[WebApiQueryable]
		public SingleResult<StateProvince> GetStateProvince(int key)
		{
			return GetSingleResult(key);
		}

		// navigation properties

		[WebApiQueryable]
		public SingleResult<Country> GetCountry(int key)
		{
			return GetRelatedEntity(key, x => x.Country);
		}
	}
}
