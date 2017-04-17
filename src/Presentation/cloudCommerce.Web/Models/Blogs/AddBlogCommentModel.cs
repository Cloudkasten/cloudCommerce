using System.Web.Mvc;
using cloudCommerce.Web.Framework;
using cloudCommerce.Web.Framework.Modelling;

namespace cloudCommerce.Web.Models.Blogs
{
    public partial class AddBlogCommentModel : EntityModelBase
    {
        [SmartResourceDisplayName("Blog.Comments.CommentText")]
        [AllowHtml]
        public string CommentText { get; set; }

        public bool DisplayCaptcha { get; set; }
    }
}