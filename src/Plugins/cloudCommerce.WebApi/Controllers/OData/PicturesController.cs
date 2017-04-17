using cloudCommerce.Core.Domain.Catalog;
using cloudCommerce.Core.Domain.Media;
using cloudCommerce.Services.Media;
using cloudCommerce.Web.Framework.WebApi;
using cloudCommerce.Web.Framework.WebApi.OData;
using cloudCommerce.Web.Framework.WebApi.Security;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace cloudCommerce.WebApi.Controllers.OData
{
	[WebApiAuthenticate(Permission = "ManageCatalog")]
	public class PicturesController : WebApiEntityController<Picture, IPictureService>
	{
		protected override void Insert(Picture entity)
		{
			throw this.ExceptionNotImplemented();
		}
		protected override void Update(Picture entity)
		{
			throw this.ExceptionNotImplemented();
		}
		protected override void Delete(Picture entity)
		{
			Service.DeletePicture(entity);
		}

		[WebApiQueryable]
		public SingleResult<Picture> GetPicture(int key)
		{
			return GetSingleResult(key);
		}

		// navigation properties

		[WebApiQueryable]
		public IQueryable<ProductPicture> GetProductPictures(int key)
		{
			return GetRelatedCollection(key, x => x.ProductPictures);
		}
	}
}
