using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using cloudCommerce.Core.Caching;
using cloudCommerce.Core.Domain.Localization;
using cloudCommerce.Core.Domain.Stores;
using cloudCommerce.Core.Events;
using cloudCommerce.Services.Tasks;
using cloudCommerce.Services.Stores;

namespace cloudCommerce.Services
{
	public class ServiceCacheConsumer :
		IConsumer<EntityInserted<Store>>,
        IConsumer<EntityDeleted<Store>>,
        IConsumer<EntityInserted<Language>>,
        IConsumer<EntityUpdated<Language>>,
        IConsumer<EntityDeleted<Language>>
	{
		public const string STORE_LANGUAGE_MAP_KEY = "sm.svc.storelangmap";

		private readonly ICacheManager _cacheManager;

        public ServiceCacheConsumer(Func<string, ICacheManager> cache)
        {
			this._cacheManager = cache("static");
        }

		public void HandleEvent(EntityInserted<Store> eventMessage)
		{
			_cacheManager.Remove(STORE_LANGUAGE_MAP_KEY);
		}

		public void HandleEvent(EntityDeleted<Store> eventMessage)
		{
			_cacheManager.Remove(STORE_LANGUAGE_MAP_KEY);
		}

		public void HandleEvent(EntityInserted<Language> eventMessage)
		{
			_cacheManager.Remove(STORE_LANGUAGE_MAP_KEY);
		}

		public void HandleEvent(EntityUpdated<Language> eventMessage)
		{
			_cacheManager.Remove(STORE_LANGUAGE_MAP_KEY);
		}

		public void HandleEvent(EntityDeleted<Language> eventMessage)
		{
			_cacheManager.Remove(STORE_LANGUAGE_MAP_KEY);
		}
    }
}
