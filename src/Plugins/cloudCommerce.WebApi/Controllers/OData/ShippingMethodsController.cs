using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using cloudCommerce.Core.Domain.Directory;
using cloudCommerce.Core.Domain.Shipping;
using cloudCommerce.Services.Shipping;
using cloudCommerce.Web.Framework.WebApi;
using cloudCommerce.Web.Framework.WebApi.OData;
using cloudCommerce.Web.Framework.WebApi.Security;

namespace cloudCommerce.WebApi.Controllers.OData
{
	[WebApiAuthenticate(Permission = "ManageShippingSettings")]
	public class ShippingMethodsController : WebApiEntityController<ShippingMethod, IShippingService>
	{
		protected override void Insert(ShippingMethod entity)
		{
			Service.InsertShippingMethod(entity);
		}
		protected override void Update(ShippingMethod entity)
		{
			Service.UpdateShippingMethod(entity);
		}
		protected override void Delete(ShippingMethod entity)
		{
			Service.DeleteShippingMethod(entity);
		}

		[WebApiQueryable]
		public SingleResult<ShippingMethod> GetShippingMethod(int key)
		{
			return GetSingleResult(key);
		}

		// navigation properties

		[WebApiQueryable]
		public IQueryable<Country> GetRestrictedCountries(int key)
		{
			return GetRelatedCollection(key, x => x.RestrictedCountries);
		}
	}
}
