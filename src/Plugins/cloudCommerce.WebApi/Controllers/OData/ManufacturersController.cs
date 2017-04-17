using System;
using System.Linq;
using System.Web.Http;
using cloudCommerce.Core.Domain.Catalog;
using cloudCommerce.Services.Catalog;
using cloudCommerce.Services.Seo;
using cloudCommerce.Web.Framework.WebApi;
using cloudCommerce.Web.Framework.WebApi.Security;
using cloudCommerce.Web.Framework.WebApi.OData;

namespace cloudCommerce.WebApi.Controllers.OData
{
	[WebApiAuthenticate(Permission = "ManageCatalog")]
	public class ManufacturersController : WebApiEntityController<Manufacturer, IManufacturerService>
	{
		private readonly Lazy<IUrlRecordService> _urlRecordService;

		public ManufacturersController(Lazy<IUrlRecordService> urlRecordService)
		{
			_urlRecordService = urlRecordService;
		}

		protected override IQueryable<Manufacturer> GetEntitySet()
		{
			var query =
				from x in this.Repository.Table
				where !x.Deleted
				select x;

			return query;
		}
		protected override void Insert(Manufacturer entity)
		{
			Service.InsertManufacturer(entity);

			this.ProcessEntity(() =>
			{
				_urlRecordService.Value.SaveSlug<Manufacturer>(entity, x => x.Name);
				return null;
			});
		}
		protected override void Update(Manufacturer entity)
		{
			Service.UpdateManufacturer(entity);

			this.ProcessEntity(() =>
			{
				_urlRecordService.Value.SaveSlug<Manufacturer>(entity, x => x.Name);
				return null;
			});
		}
		protected override void Delete(Manufacturer entity)
		{
			Service.DeleteManufacturer(entity);
		}

		[WebApiQueryable]
		public SingleResult<Manufacturer> GetManufacturer(int key)
		{
			return GetSingleResult(key);
		}
	}
}
