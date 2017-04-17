using System.Collections.Generic;
using cloudCommerce.Web.Framework.Modelling;
using cloudCommerce.Web.Models.Common;

namespace cloudCommerce.Web.Models.Customer
{
    public partial class CustomerAddressListModel : ModelBase
    {
        public CustomerAddressListModel()
        {
            Addresses = new List<AddressModel>();
        }

        public IList<AddressModel> Addresses { get; set; }
        public CustomerNavigationModel NavigationModel { get; set; }
    }
}