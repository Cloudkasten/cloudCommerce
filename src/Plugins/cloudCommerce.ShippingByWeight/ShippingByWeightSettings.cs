
using cloudCommerce.Core.Configuration;

namespace cloudCommerce.ShippingByWeight
{
    public class ShippingByWeightSettings : ISettings
    {
        public bool LimitMethodsToCreated { get; set; }

        public bool CalculatePerWeightUnit { get; set; }
    }
}