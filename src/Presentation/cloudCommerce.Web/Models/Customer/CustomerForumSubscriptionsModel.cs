using System.Collections.Generic;
using cloudCommerce.Core;

namespace cloudCommerce.Web.Models.Customer
{
    public partial class CustomerForumSubscriptionsModel : PagedListBase
    {
        public CustomerForumSubscriptionsModel(IPageable pageable) : base(pageable)
        {
            this.ForumSubscriptions = new List<ForumSubscriptionModel>();
        }

        public IList<ForumSubscriptionModel> ForumSubscriptions { get; set; }
        public CustomerNavigationModel NavigationModel { get; set; }
    }
}