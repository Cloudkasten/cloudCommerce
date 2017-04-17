using System.Web.Http;
using cloudCommerce.Core.Domain.Catalog;
using cloudCommerce.Services.Catalog;
using cloudCommerce.Web.Framework.WebApi;
using cloudCommerce.Web.Framework.WebApi.OData;
using cloudCommerce.Web.Framework.WebApi.Security;

namespace cloudCommerce.WebApi.Controllers.OData
{
	[WebApiAuthenticate(Permission = "ManageCatalog")]
	public class TierPricesController : WebApiEntityController<TierPrice, IProductService>
	{
		protected override void Insert(TierPrice entity)
		{
			Service.InsertTierPrice(entity);
		}
		protected override void Update(TierPrice entity)
		{
			Service.UpdateTierPrice(entity);
		}
		protected override void Delete(TierPrice entity)
		{
			Service.DeleteTierPrice(entity);
		}

		[WebApiQueryable]
		public SingleResult<TierPrice> GetTierPrice(int key)
		{
			return GetSingleResult(key);
		}
	}
}
