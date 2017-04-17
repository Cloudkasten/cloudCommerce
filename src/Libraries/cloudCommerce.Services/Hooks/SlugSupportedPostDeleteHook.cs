using System;
using cloudCommerce.Core;
using cloudCommerce.Core.Data.Hooks;
using cloudCommerce.Core.Domain.Seo;
using cloudCommerce.Services.Seo;

namespace cloudCommerce.Services.Common
{
	public class SlugSupportedPostDeleteHook : PostDeleteHook<ISlugSupported>
	{
		private readonly Lazy<IUrlRecordService> _urlRecordService;

		public SlugSupportedPostDeleteHook(Lazy<IUrlRecordService> urlRecordService)
		{
			this._urlRecordService = urlRecordService;
		}

		public override void Hook(ISlugSupported entity, HookEntityMetadata metadata)
		{
			var baseEntity = entity as BaseEntity;

			if (baseEntity == null)
				return;

			var entityType = baseEntity.GetUnproxiedType();

			var records = _urlRecordService.Value.GetUrlRecordsFor(entityType.Name, baseEntity.Id);
			records.Each(x => _urlRecordService.Value.DeleteUrlRecord(x));
		}
	}
}
