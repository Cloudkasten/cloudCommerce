using cloudCommerce.Web.Framework.Modelling;

namespace cloudCommerce.Admin.Models.Customers
{
    public class CustomerReportsModel : ModelBase
    {
        public BestCustomersReportModel BestCustomersByOrderTotal { get; set; }
        public BestCustomersReportModel BestCustomersByNumberOfOrders { get; set; }
    }
}