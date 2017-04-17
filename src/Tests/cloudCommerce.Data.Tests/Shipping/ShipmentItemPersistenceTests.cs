using System;
using cloudCommerce.Core.Domain.Common;
using cloudCommerce.Core.Domain.Customers;
using cloudCommerce.Core.Domain.Directory;
using cloudCommerce.Core.Domain.Orders;
using cloudCommerce.Core.Domain.Shipping;
using cloudCommerce.Tests;
using NUnit.Framework;

namespace cloudCommerce.Data.Tests.Shipping
{
    [TestFixture]
    public class ShipmentItemPersistenceTests : PersistenceTest
    {
        [Test]
        public void Can_save_and_load_shipmentItem()
        {
            var shipmentItem = new ShipmentItem()
            {
                Shipment = GetTestShipment(),
                OrderItemId = 2,
                Quantity = 3, 
            };

            var fromDb = SaveAndLoadEntity(shipmentItem);
            fromDb.ShouldNotBeNull();
            fromDb.Shipment.ShouldNotBeNull();
            fromDb.OrderItemId.ShouldEqual(2);
            fromDb.Quantity.ShouldEqual(3);
        }

        protected Shipment GetTestShipment()
        {
            return new Shipment
            {
                Order = GetTestOrder(),
                TrackingNumber = "TrackingNumber 1",
                ShippedDateUtc = new DateTime(2010, 01, 01),
                DeliveryDateUtc = new DateTime(2010, 01, 02),
                CreatedOnUtc = new DateTime(2010, 01, 03),
            };
        }

        protected Customer GetTestCustomer()
        {
            return new Customer
            {
                CustomerGuid = Guid.NewGuid(),
                AdminComment = "some comment here",
                Active = true,
                Deleted = false,
                CreatedOnUtc = new DateTime(2010, 01, 01),
                LastActivityDateUtc = new DateTime(2010, 01, 02)
            };
        }

        protected Order GetTestOrder()
        {
            return new Order()
            {
                OrderGuid = Guid.NewGuid(),
                Customer = GetTestCustomer(),
                BillingAddress = new Address()
                {
                    Country = new Country()
                    {
                        Name = "United States",
                        TwoLetterIsoCode = "US",
                        ThreeLetterIsoCode = "USA",
                    },
                    CreatedOnUtc = new DateTime(2010, 01, 01),
                },
                Deleted = true,
				CreatedOnUtc = new DateTime(2010, 01, 01),
				UpdatedOnUtc = new DateTime(2010, 01, 01)
            };
        }
    }
}