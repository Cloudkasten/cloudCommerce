using System;
using System.IO;
using NuGet;

namespace cloudCommerce.Core.Packaging
{
	public interface IPackageManager
	{
		PackageInfo Install(Stream packageStream, string location, string applicationPath);
		void Uninstall(string packageId, string applicationPath);

		PackagingResult BuildPluginPackage(string pluginName);
		PackagingResult BuildThemePackage(string themeName);
	}
} 
