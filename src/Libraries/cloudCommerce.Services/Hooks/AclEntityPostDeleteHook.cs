using System;
using cloudCommerce.Core;
using cloudCommerce.Core.Data.Hooks;
using cloudCommerce.Core.Domain.Security;
using cloudCommerce.Services.Security;

namespace cloudCommerce.Services.Common
{
	public class AclEntityPostDeleteHook : PostDeleteHook<IAclSupported>
	{
		private readonly Lazy<IAclService> _aclService;

		public AclEntityPostDeleteHook(Lazy<IAclService> aclService)
		{
			this._aclService = aclService;
		}

		public override void Hook(IAclSupported entity, HookEntityMetadata metadata)
		{
			var baseEntity = entity as BaseEntity;

			if (baseEntity == null)
				return;

			var entityType = baseEntity.GetUnproxiedType();

			var records = _aclService.Value.GetAclRecordsFor(entityType.Name, baseEntity.Id);
			records.Each(x => _aclService.Value.DeleteAclRecord(x));
		}
	}
}
