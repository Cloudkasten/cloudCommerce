using cloudCommerce.Core.Domain.Common;
using cloudCommerce.Core.Domain.Customers;
using cloudCommerce.Core.Domain.Orders;
using cloudCommerce.Services.Customers;
using cloudCommerce.Web.Framework.WebApi;
using cloudCommerce.Web.Framework.WebApi.OData;
using cloudCommerce.Web.Framework.WebApi.Security;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace cloudCommerce.WebApi.Controllers.OData
{
	[WebApiAuthenticate(Permission = "ManageCustomers")]
	public class CustomersController : WebApiEntityController<Customer, ICustomerService>
	{
		protected override IQueryable<Customer> GetEntitySet()
		{
			var query =
				from x in this.Repository.Table
				where !x.Deleted
				select x;

			return query;
		}
		protected override void Insert(Customer entity)
		{
			Service.InsertCustomer(entity);
		}
		protected override void Update(Customer entity)
		{
			Service.UpdateCustomer(entity);
		}
		protected override void Delete(Customer entity)
		{
			Service.DeleteCustomer(entity);
		}

		[WebApiQueryable]
		public SingleResult<Customer> GetCustomer(int key)
		{
			return GetSingleResult(key);
		}

		// navigation properties

		[WebApiQueryable]
		public SingleResult<Address> GetBillingAddress(int key)
		{
			return GetRelatedEntity(key, x => x.BillingAddress);
		}

		[WebApiQueryable]
		public SingleResult<Address> GetShippingAddress(int key)
		{
			return GetRelatedEntity(key, x => x.ShippingAddress);
		}

		//public Language GetLanguage(int key)
		//{
		//	return GetExpandedProperty<Language>(key, x => x.Language);
		//}

		//public Currency GetCurrency(int key)
		//{
		//	return GetExpandedProperty<Currency>(key, x => x.Currency);
		//}

		[WebApiQueryable]
		public IQueryable<Order> GetOrders(int key)
		{
			return GetRelatedCollection(key, x => x.Orders);
		}

		[WebApiQueryable]
		public IQueryable<ReturnRequest> GetReturnRequests(int key)
		{
			return GetRelatedCollection(key, x => x.ReturnRequests);
		}

		[WebApiQueryable]
		public IQueryable<Address> GetAddresses(int key)
		{
			return GetRelatedCollection(key, x => x.Addresses);
		}

		// actions

		//[HttpGet, Queryable]
		//public IQueryable<GenericAttribute> GetGenericAttributes(int key)
		//{
		//	var query = GenericAttributes(key, "Customer");

		//	return query;
		//}
	}
}
