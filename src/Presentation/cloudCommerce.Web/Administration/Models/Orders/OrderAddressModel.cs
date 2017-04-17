using cloudCommerce.Admin.Models.Common;
using cloudCommerce.Web.Framework.Modelling;

namespace cloudCommerce.Admin.Models.Orders
{
    public class OrderAddressModel : ModelBase
    {
        public int OrderId { get; set; }

        public AddressModel Address { get; set; }
    }
}