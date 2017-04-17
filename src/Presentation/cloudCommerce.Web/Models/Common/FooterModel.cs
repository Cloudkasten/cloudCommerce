using System.Collections.Generic;
using cloudCommerce.Web.Framework.Modelling;

namespace cloudCommerce.Web.Models.Common
{
    public partial class FooterModel : ModelBase
    {
        public string StoreName { get; set; }

        public string LegalInfo { get; set; }
        public bool ShowLegalInfo { get; set; }
        public bool ShowThemeSelector { get; set; }
        public string NewsletterEmail { get; set; }
		public string cloudCommerceHint { get; set; }
        public bool HideNewsletterBlock { get; set; }
        public bool BlogEnabled { get; set; }
        public bool ForumEnabled { get; set; }

        public bool ShowSocialLinks { get; set; }
        public string FacebookLink { get; set; }
        public string GooglePlusLink { get; set; }
        public string TwitterLink { get; set; }
        public string PinterestLink { get; set; }
        public string YoutubeLink { get; set; }

		public Dictionary<string, string> TopicPageUrls { get; set; }
	}
}