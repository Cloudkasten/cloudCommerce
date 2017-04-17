using System.Web.Http;
using cloudCommerce.Core.Domain.Customers;
using cloudCommerce.Core.Domain.Orders;
using cloudCommerce.Services.Orders;
using cloudCommerce.Web.Framework.WebApi;
using cloudCommerce.Web.Framework.WebApi.OData;
using cloudCommerce.Web.Framework.WebApi.Security;

namespace cloudCommerce.WebApi.Controllers.OData
{
	[WebApiAuthenticate(Permission = "ManageReturnRequests")]
	public class ReturnRequestsController : WebApiEntityController<ReturnRequest, IOrderService>
	{
		protected override void Delete(ReturnRequest entity)
		{
			Service.DeleteReturnRequest(entity);
		}

		[WebApiQueryable]
		public SingleResult<ReturnRequest> GetReturnRequest(int key)
		{
			return GetSingleResult(key);
		}

		// navigation properties

		[WebApiQueryable]
		public SingleResult<Customer> GetCustomer(int key)
		{
			return GetRelatedEntity(key, x => x.Customer);
		}
	}
}
