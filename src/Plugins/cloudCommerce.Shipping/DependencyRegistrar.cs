using Autofac;
using Autofac.Core;
using Autofac.Integration.Mvc;
using cloudCommerce.Core.Data;
using cloudCommerce.Core.Infrastructure;
using cloudCommerce.Core.Infrastructure.DependencyManagement;
using cloudCommerce.Data;
using cloudCommerce.Shipping.Data;
using cloudCommerce.Shipping.Domain;
using cloudCommerce.Shipping.Services;

namespace cloudCommerce.Shipping
{
    public class DependencyRegistrar : IDependencyRegistrar
    {
		public virtual void Register(ContainerBuilder builder, ITypeFinder typeFinder, bool isActiveModule)
        {
			builder.RegisterType<ShippingByTotalService>().As<IShippingByTotalService>().InstancePerRequest();

            //data layer
            //register named context
			builder.Register<IDbContext>(c => new ByTotalObjectContext(DataSettings.Current.DataConnectionString))
                .Named<IDbContext>(ByTotalObjectContext.ALIASKEY)
                .InstancePerRequest();

			builder.Register<ByTotalObjectContext>(c => new ByTotalObjectContext(DataSettings.Current.DataConnectionString))
                .InstancePerRequest();

            //override required repository with our custom context
            builder.RegisterType<EfRepository<ShippingByTotalRecord>>()
                .As<IRepository<ShippingByTotalRecord>>()
                .WithParameter(ResolvedParameter.ForNamed<IDbContext>(ByTotalObjectContext.ALIASKEY))
                .InstancePerRequest();
        }

        public int Order
        {
            get { return 1; }
        }
    }
}
