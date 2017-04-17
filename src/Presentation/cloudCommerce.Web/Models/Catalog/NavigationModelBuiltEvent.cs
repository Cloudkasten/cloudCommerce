using cloudCommerce.Collections;
using cloudCommerce.Web.Framework.UI;

namespace cloudCommerce.Web.Models.Catalog
{
    public class NavigationModelBuiltEvent
    {
        public NavigationModelBuiltEvent(TreeNode<MenuItem> rootNode)
        {
            this.RootNode = rootNode;
        }

		public TreeNode<MenuItem> RootNode { get; private set; }
    }
}