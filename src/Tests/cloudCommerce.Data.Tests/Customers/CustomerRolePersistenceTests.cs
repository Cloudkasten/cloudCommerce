using System.Linq;
using cloudCommerce.Core.Domain.Customers;
using cloudCommerce.Core.Domain.Security;
using cloudCommerce.Tests;
using NUnit.Framework;

namespace cloudCommerce.Data.Tests.Customers
{
    [TestFixture]
    public class CustomerRolePersistenceTests : PersistenceTest
    {
        [Test]
        public void Can_save_and_load_customerRole()
        {
            var customerRole = GetTestCustomerRole();

            var fromDb = SaveAndLoadEntity(customerRole);
            fromDb.ShouldNotBeNull();
            fromDb.Name.ShouldEqual("Administrators");
            fromDb.FreeShipping.ShouldEqual(true);
            fromDb.TaxExempt.ShouldEqual(true);
            fromDb.Active.ShouldEqual(true);
            fromDb.IsSystemRole.ShouldEqual(true);
            fromDb.SystemName.ShouldEqual("Administrators");
        }

        [Test]
        public void Can_save_and_load_customerRole_with_permissions()
        {
            var customerRole = GetTestCustomerRole();
            customerRole.PermissionRecords.Add
            (
                new PermissionRecord()
                {
                    Name = "Name 1",
                    SystemName = "SystemName 2",
                    Category = "Category 4",
                }
            );

            var fromDb = SaveAndLoadEntity(customerRole);
            fromDb.ShouldNotBeNull();
            fromDb.Name.ShouldEqual("Administrators");

            fromDb.PermissionRecords.ShouldNotBeNull();
            (fromDb.PermissionRecords.Count == 1).ShouldBeTrue();
            fromDb.PermissionRecords.First().Name.ShouldEqual("Name 1");
        }

        protected CustomerRole GetTestCustomerRole()
        {
            return new CustomerRole
            {
                Name = "Administrators",
                FreeShipping = true,
                TaxExempt = true,
                Active = true,
                IsSystemRole = true,
                SystemName = "Administrators"
            };
        }
    }
}