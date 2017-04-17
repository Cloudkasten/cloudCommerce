using System;
using System.Linq;
using cloudCommerce.Core;
using cloudCommerce.Core.Data.Hooks;
using cloudCommerce.Core.Domain.Security;
using cloudCommerce.Core.Domain.Stores;
using cloudCommerce.Services.Stores;

namespace cloudCommerce.Services.Common
{
	public class StoreMappingEntityPostDeleteHook : PostDeleteHook<IStoreMappingSupported>
	{
		private readonly Lazy<IStoreMappingService> _storeMappingService;

		public StoreMappingEntityPostDeleteHook(Lazy<IStoreMappingService> storeMappingService)
		{
			_storeMappingService = storeMappingService;
		}

		public override void Hook(IStoreMappingSupported entity, HookEntityMetadata metadata)
		{
			var baseEntity = entity as BaseEntity;

			if (baseEntity == null)
				return;

			var entityType = baseEntity.GetUnproxiedType();

			var records = _storeMappingService.Value
				.GetStoreMappingsFor(entityType.Name, baseEntity.Id)
				.ToList();

			records.Each(x => _storeMappingService.Value.DeleteStoreMapping(x));
		}
	}
}
