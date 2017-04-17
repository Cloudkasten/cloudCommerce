using cloudCommerce.Web.Framework.Modelling;

namespace cloudCommerce.Web.Models.Blogs
{
    public partial class BlogPostTagModel : ModelBase
    {
        public string Name { get; set; }

        public int BlogPostCount { get; set; }
    }
}