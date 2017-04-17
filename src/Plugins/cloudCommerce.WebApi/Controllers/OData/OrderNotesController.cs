using System.Web.Http;
using cloudCommerce.Core.Domain.Orders;
using cloudCommerce.Services.Orders;
using cloudCommerce.Web.Framework.WebApi;
using cloudCommerce.Web.Framework.WebApi.OData;
using cloudCommerce.Web.Framework.WebApi.Security;

namespace cloudCommerce.WebApi.Controllers.OData
{
	[WebApiAuthenticate(Permission = "ManageOrders")]
	public class OrderNotesController : WebApiEntityController<OrderNote, IOrderService>
	{
		protected override void Delete(OrderNote entity)
		{
			Service.DeleteOrderNote(entity);
		}

		[WebApiQueryable]
		public SingleResult<OrderNote> GetOrderNote(int key)
		{
			return GetSingleResult(key);
		}

		// navigation properties

		[WebApiQueryable]
		public SingleResult<Order> GetOrder(int key)
		{
			return GetRelatedEntity(key, x => x.Order);
		}
	}
}
