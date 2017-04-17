using System;
using System.Linq;
using cloudCommerce.Core.Domain.Affiliates;
using cloudCommerce.Core.Domain.Common;
using cloudCommerce.Core.Domain.Customers;
using cloudCommerce.Core.Domain.Directory;
using cloudCommerce.Core.Domain.Orders;
using cloudCommerce.Core.Domain.Tax;
using cloudCommerce.Tests;
using NUnit.Framework;

namespace cloudCommerce.Data.Tests.Affiliates
{
    [TestFixture]
    public class AffiliatePersistenceTests : PersistenceTest
    {
        [Test]
        public void Can_save_and_load_affiliate()
        {
            var affiliate = new Affiliate
            {
                Deleted = true,
                Active = true,
                Address = GetTestAddress(),
            };

            var fromDb = SaveAndLoadEntity(affiliate);
            fromDb.ShouldNotBeNull();
            fromDb.Deleted.ShouldEqual(true);
            fromDb.Active.ShouldEqual(true);
            fromDb.Address.ShouldNotBeNull();
            fromDb.Address.FirstName.ShouldEqual("FirstName 1");
        }

        protected Address GetTestAddress()
        {
            return new Address()
            {
                FirstName = "FirstName 1",
                LastName = "LastName 1",
                Email = "Email 1",
                Company = "Company 1",
                City = "City 1",
                Address1 = "Address1a",
                Address2 = "Address1a",
                ZipPostalCode = "ZipPostalCode 1",
                PhoneNumber = "PhoneNumber 1",
                FaxNumber = "FaxNumber 1",
                CreatedOnUtc = new DateTime(2010, 01, 01),
                Country = new Country
                {
                    Name = "United States",
                    TwoLetterIsoCode = "US",
                    ThreeLetterIsoCode = "USA",
                }
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
				CreatedOnUtc = new DateTime(2010, 05, 06),
				UpdatedOnUtc = new DateTime(2010, 01, 01)
            };
        }
    }
}
