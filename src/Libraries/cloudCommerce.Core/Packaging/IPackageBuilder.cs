using System;
using System.IO;
using cloudCommerce.Core.Themes;
using cloudCommerce.Core.Plugins;

namespace cloudCommerce.Core.Packaging
{
	public interface IPackageBuilder
	{
		Stream BuildPackage(PluginDescriptor pluginDescriptor);
		Stream BuildPackage(ThemeManifest themeManifest);
	}
}
