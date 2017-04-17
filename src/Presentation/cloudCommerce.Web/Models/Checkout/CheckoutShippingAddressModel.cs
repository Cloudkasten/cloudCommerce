using System.Collections.Generic;
using cloudCommerce.Web.Framework.Modelling;
using cloudCommerce.Web.Models.Common;

namespace cloudCommerce.Web.Models.Checkout
{
    public partial class CheckoutShippingAddressModel : ModelBase
    {
        public CheckoutShippingAddressModel()
        {
            ExistingAddresses = new List<AddressModel>();
            NewAddress = new AddressModel();
        }

        public IList<AddressModel> ExistingAddresses { get; set; }

        public AddressModel NewAddress { get; set; }

        public bool NewAddressPreselected { get; set; }
    }
}