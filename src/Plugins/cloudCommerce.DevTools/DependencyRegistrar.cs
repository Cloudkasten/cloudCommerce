using Autofac;
using Autofac.Integration.Mvc;
using cloudCommerce.Core.Data;
using cloudCommerce.Core.Infrastructure;
using cloudCommerce.Core.Infrastructure.DependencyManagement;
using cloudCommerce.DevTools.Filters;
using cloudCommerce.DevTools.Services;
using cloudCommerce.Web.Framework.Controllers;

namespace cloudCommerce.DevTools
{
	public class DependencyRegistrar : IDependencyRegistrar
    {
		public virtual void Register(ContainerBuilder builder, ITypeFinder typeFinder, bool isActiveModule)
        {
			builder.RegisterType<ProfilerService>().As<IProfilerService>().InstancePerRequest();

			if (isActiveModule && DataSettings.DatabaseIsInstalled())
			{
				// intercept ALL public store controller actions
				builder.RegisterType<ProfilerFilter>().AsActionFilterFor<SmartController>();
                builder.RegisterType<WidgetZoneFilter>().AsActionFilterFor<SmartController>();
                
				//// intercept CatalogController's Product action
				//builder.RegisterType<SampleResultFilter>().AsResultFilterFor<CatalogController>(x => x.Product(default(int), default(string))).InstancePerRequest();
				//builder.RegisterType<SampleActionFilter>().AsActionFilterFor<PublicControllerBase>().InstancePerRequest();
				//// intercept CheckoutController's Index action (to hijack the checkout or payment workflow)
				//builder.RegisterType<SampleCheckoutFilter>().AsActionFilterFor<CheckoutController>(x => x.Index()).InstancePerRequest();
			}
        }

        public int Order
        {
            get { return 1; }
        }
    }
}
