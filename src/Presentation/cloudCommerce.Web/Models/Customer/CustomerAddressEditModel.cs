using cloudCommerce.Web.Framework.Modelling;
using cloudCommerce.Web.Models.Common;

namespace cloudCommerce.Web.Models.Customer
{
    public partial class CustomerAddressEditModel : ModelBase
    {
        public CustomerAddressEditModel()
        {
            this.Address = new AddressModel();
        }
        public AddressModel Address { get; set; }
        public CustomerNavigationModel NavigationModel { get; set; }
    }
}