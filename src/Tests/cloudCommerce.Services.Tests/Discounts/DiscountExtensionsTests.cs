using cloudCommerce.Core.Domain.Customers;
using cloudCommerce.Core.Domain.Discounts;
using cloudCommerce.Services.Discounts;
using cloudCommerce.Tests;
using NUnit.Framework;

namespace cloudCommerce.Services.Tests.Discounts
{
    [TestFixture]
    public class DiscountExtensionsTests : ServiceTest
    {
        [Test]
        public void Can_calculate_discount_amount_percentage()
        {
            var discount = new Discount()
            {
                UsePercentage = true,
                DiscountPercentage = 30
            };

            discount.GetDiscountAmount(100).ShouldEqual(30);

            discount.DiscountPercentage = 60;
            discount.GetDiscountAmount(200).ShouldEqual(120);
        }
        [Test]
        public void Can_calculate_discount_amount_fixed()
        {
            var discount = new Discount()
            {
                UsePercentage = false,
                DiscountAmount = 10
            };

            discount.GetDiscountAmount(100).ShouldEqual(10);

            discount.DiscountAmount = 20;
            discount.GetDiscountAmount(200).ShouldEqual(20);
        }
    }
}
