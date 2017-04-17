using System.Web.Http;
using cloudCommerce.Core.Domain.Directory;
using cloudCommerce.Services.Directory;
using cloudCommerce.Web.Framework.WebApi;
using cloudCommerce.Web.Framework.WebApi.OData;
using cloudCommerce.Web.Framework.WebApi.Security;

namespace cloudCommerce.WebApi.Controllers.OData
{
	[WebApiAuthenticate(Permission = "ManageMeasures")]
	public class QuantityUnitsController : WebApiEntityController<QuantityUnit, IQuantityUnitService>
	{
		protected override void Insert(QuantityUnit entity)
		{
			Service.InsertQuantityUnit(entity);
		}
		protected override void Update(QuantityUnit entity)
		{
			Service.UpdateQuantityUnit(entity);
		}
		protected override void Delete(QuantityUnit entity)
		{
			Service.DeleteQuantityUnit(entity);
		}

		[WebApiQueryable]
		public SingleResult<QuantityUnit> GetQuantityUnit(int key)
		{
			return GetSingleResult(key);
		}
	}
}
