using cloudCommerce.Core.Domain.Catalog;
using cloudCommerce.Core.Domain.Discounts;
using cloudCommerce.Services.Discounts;
using cloudCommerce.Web.Framework.WebApi;
using cloudCommerce.Web.Framework.WebApi.OData;
using cloudCommerce.Web.Framework.WebApi.Security;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace cloudCommerce.WebApi.Controllers.OData
{
	[WebApiAuthenticate(Permission = "ManageDiscounts")]
	public class DiscountsController : WebApiEntityController<Discount, IDiscountService>
	{
		protected override void Insert(Discount entity)
		{
			Service.InsertDiscount(entity);
		}
		protected override void Update(Discount entity)
		{
			Service.UpdateDiscount(entity);
		}
		protected override void Delete(Discount entity)
		{
			Service.DeleteDiscount(entity);
		}

		[WebApiQueryable]
		public SingleResult<Discount> GetDiscount(int key)
		{
			return GetSingleResult(key);
		}

		// navigation properties

		[WebApiQueryable]
		public IQueryable<Category> GetAppliedToCategories(int key)
		{
			return GetRelatedCollection(key, x => x.AppliedToCategories);
		}
	}
}
