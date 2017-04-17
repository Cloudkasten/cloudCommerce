using System.Web.Mvc;
using cloudCommerce.Web.Framework;
using cloudCommerce.Web.Framework.Modelling;

namespace cloudCommerce.Web.Models.News
{
    public partial class AddNewsCommentModel : ModelBase
    {
        [SmartResourceDisplayName("News.Comments.CommentTitle")]
        [AllowHtml]
        public string CommentTitle { get; set; }

        [SmartResourceDisplayName("News.Comments.CommentText")]
        [AllowHtml]
        public string CommentText { get; set; }

        public bool DisplayCaptcha { get; set; }
    }
}