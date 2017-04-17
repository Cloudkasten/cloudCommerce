using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cloudCommerce.Core;
using cloudCommerce.Core.Data;
using cloudCommerce.Core.Data.Hooks;
using cloudCommerce.Core.Domain.Localization;
using cloudCommerce.Services.Localization;

namespace cloudCommerce.Services.Hooks
{
    
    public class LocalizedEntityPostDeleteHook : PostDeleteHook<ILocalizedEntity>
    {
        private readonly ILocalizedEntityService _localizedEntityService;

        public LocalizedEntityPostDeleteHook(ILocalizedEntityService localizedEntityService)
        {
            this._localizedEntityService = localizedEntityService;
        }

        public override void Hook(ILocalizedEntity entity, HookEntityMetadata metadata)
        {
            var baseEntity = entity as BaseEntity;

            if (baseEntity == null)
                return;

            var entityType = baseEntity.GetUnproxiedType();
            var localizedEntities = this._localizedEntityService.GetLocalizedProperties(baseEntity.Id, entityType.Name);

            localizedEntities.Each(x => this._localizedEntityService.DeleteLocalizedProperty(x));
        }
    }

}
