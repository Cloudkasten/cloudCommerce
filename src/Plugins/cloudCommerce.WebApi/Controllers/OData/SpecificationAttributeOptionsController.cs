using cloudCommerce.Core.Domain.Catalog;
using cloudCommerce.Services.Catalog;
using cloudCommerce.Web.Framework.WebApi;
using cloudCommerce.Web.Framework.WebApi.OData;
using cloudCommerce.Web.Framework.WebApi.Security;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace cloudCommerce.WebApi.Controllers.OData
{
	[WebApiAuthenticate(Permission = "ManageCatalog")]
	public class SpecificationAttributeOptionsController : WebApiEntityController<SpecificationAttributeOption, ISpecificationAttributeService>
	{
		protected override void Insert(SpecificationAttributeOption entity)
		{
			Service.InsertSpecificationAttributeOption(entity);
		}
		protected override void Update(SpecificationAttributeOption entity)
		{
			Service.UpdateSpecificationAttributeOption(entity);
		}
		protected override void Delete(SpecificationAttributeOption entity)
		{
			Service.DeleteSpecificationAttributeOption(entity);
		}

		[WebApiQueryable]
		public SingleResult<SpecificationAttributeOption> GetSpecificationAttributeOption(int key)
		{
			return GetSingleResult(key);
		}

		// navigation properties

		[WebApiQueryable]
		public SingleResult<SpecificationAttribute> GetSpecificationAttribute(int key)
		{
			return GetRelatedEntity(key, x => x.SpecificationAttribute);
		}

		[WebApiQueryable]
		public IQueryable<ProductSpecificationAttribute> GetProductSpecificationAttributes(int key)
		{
			return GetRelatedCollection(key, x => x.ProductSpecificationAttributes);
		}
	}
}
