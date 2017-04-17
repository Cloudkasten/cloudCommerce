using System.Collections.Generic;
using cloudCommerce.Core;

namespace cloudCommerce.Web.Models.Customer
{
    public partial class CustomerBackInStockSubscriptionsModel : PagedListBase
    {
        public CustomerBackInStockSubscriptionsModel(IPageable pageable) : base(pageable)
        {
            this.Subscriptions = new List<BackInStockSubscriptionModel>();
        }

        public IList<BackInStockSubscriptionModel> Subscriptions { get; set; }
        public CustomerNavigationModel NavigationModel { get; set; }
    }
}