using System.Web.Http;
using cloudCommerce.Core.Domain.Common;
using cloudCommerce.Services.Common;
using cloudCommerce.Web.Framework.WebApi;
using cloudCommerce.Web.Framework.WebApi.OData;
using cloudCommerce.Web.Framework.WebApi.Security;

namespace cloudCommerce.WebApi.Controllers.OData
{
	[WebApiAuthenticate(Permission = "ManageMaintenance")]
	public class GenericAttributesController : WebApiEntityController<GenericAttribute, IGenericAttributeService>
	{
		protected override void Insert(GenericAttribute entity)
		{
			Service.InsertAttribute(entity);
		}
		protected override void Update(GenericAttribute entity)
		{
			Service.UpdateAttribute(entity);
		}
		protected override void Delete(GenericAttribute entity)
		{
			Service.DeleteAttribute(entity);
		}

		[WebApiQueryable]
		public SingleResult<GenericAttribute> GetGenericAttribute(int key)
		{
			return GetSingleResult(key);
		}
	}
}
