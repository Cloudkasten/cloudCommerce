using cloudCommerce.Web.Framework;
using cloudCommerce.Web.Framework.Modelling;

namespace cloudCommerce.Admin.Models.Customers
{
    public class RegisteredCustomerReportLineModel : ModelBase
    {
        [SmartResourceDisplayName("Admin.Customers.Reports.RegisteredCustomers.Fields.Period")]
        public string Period { get; set; }

        [SmartResourceDisplayName("Admin.Customers.Reports.RegisteredCustomers.Fields.Customers")]
        public int Customers { get; set; }
    }
}