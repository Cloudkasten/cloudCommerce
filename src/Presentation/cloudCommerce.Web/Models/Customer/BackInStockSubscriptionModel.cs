using cloudCommerce.Web.Framework.Modelling;

namespace cloudCommerce.Web.Models.Customer
{
    public partial class BackInStockSubscriptionModel : EntityModelBase
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string SeName { get; set; }
    }
}
