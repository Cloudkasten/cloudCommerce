using System;

namespace cloudCommerce.Core.Plugins
{
	[AttributeUsage(AttributeTargets.Class, AllowMultiple=false, Inherited=false)]
	public sealed class SystemNameAttribute : Attribute
	{
		public SystemNameAttribute(string name)
		{
			Guard.ArgumentNotEmpty(() => name);
			Name = name;
		}

		public string Name { get; set; }
	}
}
