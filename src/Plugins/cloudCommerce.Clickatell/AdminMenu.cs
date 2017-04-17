using cloudCommerce.Collections;
using cloudCommerce.Web.Framework.UI;

namespace cloudCommerce.Clickatell
{
	public class AdminMenu : AdminMenuProvider
	{
		protected override void BuildMenuCore(TreeNode<MenuItem> pluginsNode)
		{
			var menuItem = new MenuItem().ToBuilder()
				.Text("Clickatell SMS Provider")
				.ResKey("Plugins.FriendlyName.cloudCommerce.Clickatell")
				.Icon("send-o")
				.Action("ConfigurePlugin", "Plugin", new { systemName = "cloudCommerce.Clickatell", area = "Admin" })
				.ToItem();

			pluginsNode.Prepend(menuItem);
		}

		public override int Ordinal
		{
			get
			{
				return 100;
			}
		}

	}
}
