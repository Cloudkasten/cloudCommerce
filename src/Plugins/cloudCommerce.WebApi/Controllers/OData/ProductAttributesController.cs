using System.Web.Http;
using cloudCommerce.Core.Domain.Catalog;
using cloudCommerce.Services.Catalog;
using cloudCommerce.Web.Framework.WebApi;
using cloudCommerce.Web.Framework.WebApi.OData;
using cloudCommerce.Web.Framework.WebApi.Security;

namespace cloudCommerce.WebApi.Controllers.OData
{
	[WebApiAuthenticate(Permission = "ManageCatalog")]
	public class ProductAttributesController : WebApiEntityController<ProductAttribute, IProductAttributeService>
	{
		protected override void Insert(ProductAttribute entity)
		{
			Service.InsertProductAttribute(entity);
		}
		protected override void Update(ProductAttribute entity)
		{
			Service.UpdateProductAttribute(entity);
		}
		protected override void Delete(ProductAttribute entity)
		{
			Service.DeleteProductAttribute(entity);
		}

		[WebApiQueryable]
		public SingleResult<ProductAttribute> GetProductAttribute(int key)
		{
			return GetSingleResult(key);
		}
	}
}
