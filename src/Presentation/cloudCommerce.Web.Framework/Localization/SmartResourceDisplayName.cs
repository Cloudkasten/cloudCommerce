using System;
using System.Runtime.CompilerServices;
using cloudCommerce.Core;
using cloudCommerce.Core.Infrastructure;
using cloudCommerce.Services.Localization;
using cloudCommerce.Web.Framework.Modelling;

namespace cloudCommerce.Web.Framework
{
    public class SmartResourceDisplayName : System.ComponentModel.DisplayNameAttribute, IModelAttribute
    {
        private readonly string _callerPropertyName;

        public SmartResourceDisplayName(string resourceKey, [CallerMemberName] string propertyName = null)
            : base(resourceKey)
        {
            ResourceKey = resourceKey;
            _callerPropertyName = propertyName;
        }

        public string ResourceKey { get; set; }

        public override string DisplayName
        {
            get
            {
                string value = null;
                var langId = EngineContext.Current.Resolve<IWorkContext>().WorkingLanguage.Id;
                value = EngineContext.Current.Resolve<ILocalizationService>().GetResource(ResourceKey, langId, true, "" /* ResourceKey */, true);

                if (value.IsEmpty() && _callerPropertyName.HasValue())
                {
                    value = _callerPropertyName.SplitPascalCase();
                }

                return value;
            }
        }

        public string Name
        {
            get { return "SmartResourceDisplayName"; }
        }
    }
}
