using System;
using cloudCommerce.Core.Plugins;

namespace cloudCommerce.Core.Events
{
	public class EventConsumerMetadata
	{
		public bool ExecuteAsync { get; set; }
		public bool IsActive { get; set; }
		public PluginDescriptor PluginDescriptor { get; set; }
	}
}
