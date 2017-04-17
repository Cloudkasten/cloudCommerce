using System;
using System.Linq;
using System.Web.Http;
using cloudCommerce.Core.Data;
using cloudCommerce.Core.Domain.Common;
using cloudCommerce.Core.Domain.Directory;
using cloudCommerce.Core.Domain.Orders;
using cloudCommerce.Core.Events;
using cloudCommerce.Services.Common;
using cloudCommerce.Services.Orders;
using cloudCommerce.Web.Framework.WebApi;
using cloudCommerce.Web.Framework.WebApi.OData;
using cloudCommerce.Web.Framework.WebApi.Security;

namespace cloudCommerce.WebApi.Controllers.OData
{
	[WebApiAuthenticate(Permission = "ManageCustomers")]
	public class AddressesController : WebApiEntityController<Address, IAddressService>
	{
		private readonly Lazy<IRepository<Order>> _orderRepository;
		private readonly Lazy<IEventPublisher> _eventPublisher;

		public AddressesController(
			Lazy<IRepository<Order>> orderRepository,
			Lazy<IEventPublisher> eventPublisher)
		{
			_orderRepository = orderRepository;
			_eventPublisher = eventPublisher;
		}

		private void PublishOrderUpdated(int addressId)
		{
			this.ProcessEntity(() =>
			{
				if (addressId != 0)
				{
					var orders = _orderRepository.Value.TableUntracked
						.Where(x => x.BillingAddressId == addressId || x.ShippingAddressId == addressId)
						.ToList();

					foreach (var order in orders)
					{
						_eventPublisher.Value.PublishOrderUpdated(order);
					}
				}
				return null;
			});
		}

		protected override void Insert(Address entity)
		{
			Service.InsertAddress(entity);
			PublishOrderUpdated(entity.Id);
		}
		protected override void Update(Address entity)
		{
			Service.UpdateAddress(entity);
			PublishOrderUpdated(entity.Id);
		}
		protected override void Delete(Address entity)
		{
			int entityId = (entity == null ? 0 : entity.Id);

			Service.DeleteAddress(entity);
			PublishOrderUpdated(entityId);
		}

		[WebApiQueryable]
		public SingleResult<Address> GetAddress(int key)
		{
			return GetSingleResult(key);
		}

		// navigation properties

		[WebApiQueryable]
		public SingleResult<Country> GetCountry(int key)
		{
			return GetRelatedEntity(key, x => x.Country);
		}

		[WebApiQueryable]
		public SingleResult<StateProvince> GetStateProvince(int key)
		{
			return GetRelatedEntity(key, x => x.StateProvince);
		}
	}
}
