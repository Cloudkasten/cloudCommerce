using cloudCommerce.Collections;
using cloudCommerce.Web.Framework.UI;

namespace cloudCommerce.DevTools
{
	public class AdminMenu : AdminMenuProvider
	{
		protected override void BuildMenuCore(TreeNode<MenuItem> pluginsNode)
		{
			var menuItem = new MenuItem().ToBuilder()
				.Text("Developer Tools")
				.Icon("code")
				.Action("ConfigurePlugin", "Plugin", new { systemName = "cloudCommerce.DevTools", area = "Admin" })
				.ToItem();
			
			pluginsNode.Prepend(menuItem);

			// uncomment to add to admin menu (see plugin sub-menu)
			//var backendExtensionItem = new MenuItem().ToBuilder()
			//	.Text("Backend extension")
			//	.Icon("area-chart")
			//	.Action("BackendExtension", "DevTools", new { area = "cloudCommerce.DevTools" })
			//	.ToItem();

			//pluginsNode.Append(backendExtensionItem);
		}
	}
}
