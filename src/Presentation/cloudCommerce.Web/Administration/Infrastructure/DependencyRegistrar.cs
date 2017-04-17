using Autofac;
using Autofac.Integration.Mvc;
using cloudCommerce.Core.Data;
using cloudCommerce.Core.Infrastructure;
using cloudCommerce.Core.Infrastructure.DependencyManagement;
using cloudCommerce.Web.Framework.Controllers;

namespace cloudCommerce.Admin.Infrastructure
{
    public class DependencyRegistrar : IDependencyRegistrar
    {
		public virtual void Register(ContainerBuilder builder, ITypeFinder typeFinder, bool isActiveModule)
        {
			if (DataSettings.DatabaseIsInstalled())
			{
				builder.RegisterType<PreviewModeFilter>().AsResultFilterFor<PublicControllerBase>();
			}
        }

        public int Order
        {
            get { return 100; }
        }
    }
}
