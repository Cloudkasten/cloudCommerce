using System.Web.Http;
using cloudCommerce.Core.Domain.Catalog;
using cloudCommerce.Services.Catalog;
using cloudCommerce.Web.Framework.WebApi;
using cloudCommerce.Web.Framework.WebApi.OData;
using cloudCommerce.Web.Framework.WebApi.Security;

namespace cloudCommerce.WebApi.Controllers.OData
{
	[WebApiAuthenticate(Permission = "ManageCatalog")]
	public class RelatedProductsController : WebApiEntityController<RelatedProduct, IProductService>
	{
		protected override void Insert(RelatedProduct entity)
		{
			Service.InsertRelatedProduct(entity);
		}
		protected override void Update(RelatedProduct entity)
		{
			Service.UpdateRelatedProduct(entity);
		}
		protected override void Delete(RelatedProduct entity)
		{
			Service.DeleteRelatedProduct(entity);
		}

		[WebApiQueryable]
		public SingleResult<RelatedProduct> GetRelatedProduct(int key)
		{
			return GetSingleResult(key);
		}
	}
}
