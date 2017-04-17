using cloudCommerce.Core.Domain.Customers;
using cloudCommerce.Core.Domain.Orders;
using cloudCommerce.Core.Events;

namespace cloudCommerce.Services.Orders
{
    public static class EventPublisherExtensions
    {
        /// <summary>
        /// Publishes the order paid event.
        /// </summary>
        /// <param name="eventPublisher">The event publisher.</param>
        /// <param name="order">The order.</param>
        public static void PublishOrderPaid(this IEventPublisher eventPublisher, Order order)
        {
            eventPublisher.Publish(new OrderPaidEvent(order));
        }

        /// <summary>
        /// Publishes the order placed event.
        /// </summary>
        /// <param name="eventPublisher">The event publisher.</param>
        /// <param name="order">The order.</param>
        public static void PublishOrderPlaced(this IEventPublisher eventPublisher, Order order)
        {
            eventPublisher.Publish(new OrderPlacedEvent(order));
        }

		/// <summary>
		/// Publishes the order updated event.
		/// </summary>
		/// <param name="eventPublisher">The event publisher.</param>
		/// <param name="order">The order.</param>
		public static void PublishOrderUpdated(this IEventPublisher eventPublisher, Order order)
		{
			if (order != null)
				eventPublisher.Publish(new OrderUpdatedEvent(order));
		}

		/// <summary>
		/// Publishes the migrate shopping cart event.
		/// </summary>
		/// <param name="eventPublisher">The event publisher.</param>
		/// <param name="fromCustomer">The source customer entity.</param>
		/// <param name="toCustomer">The destination customer entity.</param>
		/// <param name="storeId">Store identifier.</param>
		public static void PublishMigrateShoppingCart(this IEventPublisher eventPublisher, Customer fromCustomer, Customer toCustomer, int storeId)
		{
			if (fromCustomer != null && toCustomer != null)
				eventPublisher.Publish(new MigrateShoppingCartEvent(fromCustomer, toCustomer, storeId));
		}
    }
}