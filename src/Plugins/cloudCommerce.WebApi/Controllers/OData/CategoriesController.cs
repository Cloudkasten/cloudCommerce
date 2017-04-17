using System;
using System.Linq;
using System.Web.Http;
using System.Collections.Generic;
using cloudCommerce.Core.Domain.Catalog;
using cloudCommerce.Core.Domain.Discounts;
using cloudCommerce.Services.Catalog;
using cloudCommerce.Services.Seo;
using cloudCommerce.Web.Framework.WebApi;
using cloudCommerce.Web.Framework.WebApi.OData;
using cloudCommerce.Web.Framework.WebApi.Security;

namespace cloudCommerce.WebApi.Controllers.OData
{
	[WebApiAuthenticate(Permission = "ManageCatalog")]
	public class CategoriesController : WebApiEntityController<Category, ICategoryService>
	{
		private readonly Lazy<IUrlRecordService> _urlRecordService;

		public CategoriesController(Lazy<IUrlRecordService> urlRecordService)
		{
			_urlRecordService = urlRecordService;
		}

		protected override IQueryable<Category> GetEntitySet()
		{
			var query =
				from x in this.Repository.Table
				where !x.Deleted
				select x;

			return query;
		}
		protected override void Insert(Category entity)
		{
			Service.InsertCategory(entity);

			this.ProcessEntity(() =>
			{
				_urlRecordService.Value.SaveSlug<Category>(entity, x => x.Name);
				return null;
			});
		}
		protected override void Update(Category entity)
		{
			Service.UpdateCategory(entity);

			this.ProcessEntity(() =>
			{
				_urlRecordService.Value.SaveSlug<Category>(entity, x => x.Name);
				return null;
			});
		}
		protected override void Delete(Category entity)
		{
			Service.DeleteCategory(entity);
		}

		[WebApiQueryable]
		public SingleResult<Category> GetCategory(int key)
		{
			return GetSingleResult(key);
		}

		// navigation properties

		[WebApiQueryable]
		public IQueryable<Discount> GetAppliedDiscounts(int key)
		{
			return GetRelatedCollection(key, x => x.AppliedDiscounts);
		}
	}
}