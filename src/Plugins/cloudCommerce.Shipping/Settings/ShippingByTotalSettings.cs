using cloudCommerce.Core.Configuration;

namespace cloudCommerce.Shipping
{
    public class ShippingByTotalSettings : ISettings
    {
        public bool LimitMethodsToCreated { get; set; }

        public decimal SmallQuantityThreshold { get; set; }
        public decimal SmallQuantitySurcharge { get; set; }
    }
}
