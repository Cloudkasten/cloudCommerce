using System.Collections.Generic;
using cloudCommerce.Core;

namespace cloudCommerce.Web.Models.Profile
{
    public partial class ProfilePostsModel : PagedListBase
    {
        public ProfilePostsModel(IPageable pageable) : base(pageable)
        {
        }
        
        public IList<PostsModel> Posts { get; set; }
    }
}