using cloudCommerce.Core.Infrastructure;
using cloudCommerce.Core.Plugins;
using System;
using System.Collections.Generic;
using System.Linq;

namespace cloudCommerce.Web.Framework.WebApi.Configuration
{
	public class WebApiConfigurationPublisher : IWebApiConfigurationPublisher
	{
		private readonly ITypeFinder _typeFinder;

		public WebApiConfigurationPublisher(ITypeFinder typeFinder)
		{
			_typeFinder = typeFinder;
		}

		public void Configure(WebApiConfigurationBroadcaster configData)
		{
			var providerTypes = _typeFinder.FindClassesOfType<IWebApiConfigurationProvider>(ignoreInactivePlugins: true);
			var providers = new List<IWebApiConfigurationProvider>();

			foreach (var providerType in providerTypes)
			{
				var provider = Activator.CreateInstance(providerType) as IWebApiConfigurationProvider;
				providers.Add(provider);
			}

			providers = providers.OrderByDescending(x => x.Priority).ToList();
			providers.Each(x => x.Configure(configData));
		}
	}
}
