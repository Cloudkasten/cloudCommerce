using cloudCommerce.Collections;
using cloudCommerce.Web.Framework.UI;

namespace cloudCommerce.GoogleMerchantCenter
{
    public class AdminMenu : AdminMenuProvider
    {
		protected override void BuildMenuCore(TreeNode<MenuItem> pluginsNode)
        {
			var menuItem = new MenuItem().ToBuilder()
                .Text("Google Merchant Center")
				.ResKey("Plugins.FriendlyName.cloudCommerce.GoogleMerchantCenter")
				.Action("ConfigurePlugin", "Plugin", new { systemName = GoogleMerchantCenterFeedPlugin.SystemName, area = "Admin" })
                .ToItem();

            pluginsNode.Prepend(menuItem);
        }

    }
}
