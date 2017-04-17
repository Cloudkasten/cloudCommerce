using cloudCommerce.Admin.Models.Common;
using cloudCommerce.Web.Framework.Modelling;

namespace cloudCommerce.Admin.Models.Customers
{
    public class CustomerAddressModel : ModelBase
    {
        public int CustomerId { get; set; }

        public AddressModel Address { get; set; }
    }
}