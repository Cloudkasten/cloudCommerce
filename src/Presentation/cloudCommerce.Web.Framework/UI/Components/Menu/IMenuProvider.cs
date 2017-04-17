using System;
using System.Collections.Generic;
using System.Linq;
using cloudCommerce.Collections;

namespace cloudCommerce.Web.Framework.UI
{

	/// <summary>
	/// Enables (plugins) developers to inject menu items to menus
	/// </summary>
	public interface IMenuProvider : IOrdered
    {
        void BuildMenu(TreeNode<MenuItem> rootNode);

		/// <summary>
		/// Gets the menu name to inject the menu items into (e.g. admin, catalog etc.)
		/// </summary>
		string MenuName { get; }
    }

}
