using Autofac;
using cloudCommerce.Core;
using cloudCommerce.Core.Data;
using cloudCommerce.Core.Data.Hooks;
using cloudCommerce.Core.Domain.Security;
using cloudCommerce.Core.Domain.Seo;
using cloudCommerce.Services.Security;
using cloudCommerce.Services.Seo;

namespace cloudCommerce.Services.Hooks
{

	public class SoftDeletablePreUpdateHook : PreUpdateHook<ISoftDeletable>
	{
		private readonly IComponentContext _ctx;

		public SoftDeletablePreUpdateHook(IComponentContext ctx)
		{
			this._ctx = ctx;
		}

		public override void Hook(ISoftDeletable entity, HookEntityMetadata metadata)
		{
			var baseEntity = entity as BaseEntity;

			if (baseEntity == null)
				return;

			var dbContext = _ctx.Resolve<IDbContext>();
			var modifiedProps = dbContext.GetModifiedProperties(baseEntity);

			if (!modifiedProps.ContainsKey("Deleted"))
				return;

			var entityType = baseEntity.GetUnproxiedType();

			using (var scope = new DbContextScope(ctx: dbContext, autoCommit: false))
			{
				// mark orphaned ACL records as idle
				var aclSupported = baseEntity as IAclSupported;
				if (aclSupported != null && aclSupported.SubjectToAcl)
				{
					var shouldSetIdle = entity.Deleted;
					var rsAclRecord = _ctx.Resolve<IRepository<AclRecord>>();

					var aclService = _ctx.Resolve<IAclService>();
					var records = aclService.GetAclRecordsFor(entityType.Name, baseEntity.Id);
					foreach (var record in records)
					{
						record.IsIdle = shouldSetIdle;
						aclService.UpdateAclRecord(record);
					}
				}

				// Delete orphaned inactive UrlRecords.
				// We keep the active ones on purpose in order to be able to fully restore a soft deletable entity once we implemented the "recycle bin" feature
				var slugSupported = baseEntity as ISlugSupported;
				if (slugSupported != null && entity.Deleted)
				{
					var rsUrlRecord = _ctx.Resolve<IRepository<UrlRecord>>();

					var urlRecordService = _ctx.Resolve<IUrlRecordService>();
					var activeRecords = urlRecordService.GetUrlRecordsFor(entityType.Name, baseEntity.Id);
					foreach (var record in activeRecords)
					{
						if (!record.IsActive)
						{
							urlRecordService.DeleteUrlRecord(record);
						}
					}
				}
			}
		}

		public override bool RequiresValidation
		{
			get { return false; }
		}
	}
}
