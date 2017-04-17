using cloudCommerce.Web.Framework.Modelling;

namespace cloudCommerce.Web.Models.Customer
{
    public partial class ForumSubscriptionModel : EntityModelBase
    {
        public int ForumId { get; set; }
        public int ForumTopicId { get; set; }
        public bool TopicSubscription { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
    }
}
