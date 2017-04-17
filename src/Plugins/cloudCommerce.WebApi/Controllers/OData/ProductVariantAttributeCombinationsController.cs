using System.Web.Http;
using cloudCommerce.Core.Domain.Catalog;
using cloudCommerce.Core.Domain.Directory;
using cloudCommerce.Services.Catalog;
using cloudCommerce.Web.Framework.WebApi;
using cloudCommerce.Web.Framework.WebApi.OData;
using cloudCommerce.Web.Framework.WebApi.Security;

namespace cloudCommerce.WebApi.Controllers.OData
{
	[WebApiAuthenticate(Permission = "ManageCatalog")]
	public class ProductVariantAttributeCombinationsController : WebApiEntityController<ProductVariantAttributeCombination, IProductAttributeService>
	{
		protected override void Insert(ProductVariantAttributeCombination entity)
		{
			Service.InsertProductVariantAttributeCombination(entity);
		}
		protected override void Update(ProductVariantAttributeCombination entity)
		{
			Service.UpdateProductVariantAttributeCombination(entity);
		}
		protected override void Delete(ProductVariantAttributeCombination entity)
		{
			Service.DeleteProductVariantAttributeCombination(entity);
		}

		[WebApiQueryable]
		public SingleResult<ProductVariantAttributeCombination> GetProductVariantAttributeCombination(int key)
		{
			return GetSingleResult(key);
		}

		// navigation properties

		[WebApiQueryable]
		public SingleResult<DeliveryTime> GetDeliveryTime(int key)
		{
			return GetRelatedEntity(key, x => x.DeliveryTime);
		}
	}
}
