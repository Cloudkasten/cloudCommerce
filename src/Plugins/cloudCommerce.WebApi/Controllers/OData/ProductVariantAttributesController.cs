using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using cloudCommerce.Core.Domain.Catalog;
using cloudCommerce.Services.Catalog;
using cloudCommerce.Web.Framework.WebApi;
using cloudCommerce.Web.Framework.WebApi.OData;
using cloudCommerce.Web.Framework.WebApi.Security;

namespace cloudCommerce.WebApi.Controllers.OData
{
	[WebApiAuthenticate(Permission = "ManageCatalog")]
	public class ProductVariantAttributesController : WebApiEntityController<ProductVariantAttribute, IProductAttributeService>
	{
		protected override void Insert(ProductVariantAttribute entity)
		{
			Service.InsertProductVariantAttribute(entity);
		}
		protected override void Update(ProductVariantAttribute entity)
		{
			Service.UpdateProductVariantAttribute(entity);
		}
		protected override void Delete(ProductVariantAttribute entity)
		{
			Service.DeleteProductVariantAttribute(entity);
		}

		[WebApiQueryable]
		public SingleResult<ProductVariantAttribute> GetProductVariantAttribute(int key)
		{
			return GetSingleResult(key);
		}

		// navigation properties

		[WebApiQueryable]
		public SingleResult<ProductAttribute> GetProductAttribute(int key)
		{
			return GetRelatedEntity(key, x => x.ProductAttribute);
		}

		[WebApiQueryable]
		public IQueryable<ProductVariantAttributeValue> GetProductVariantAttributeValues(int key)
		{
			return GetRelatedCollection(key, x => x.ProductVariantAttributeValues);
		}
	}
}
