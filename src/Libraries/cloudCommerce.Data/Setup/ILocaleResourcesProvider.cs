using System;

namespace cloudCommerce.Data.Setup
{
	
	public interface ILocaleResourcesProvider
	{
		void MigrateLocaleResources(LocaleResourcesBuilder builder);
	}

}
