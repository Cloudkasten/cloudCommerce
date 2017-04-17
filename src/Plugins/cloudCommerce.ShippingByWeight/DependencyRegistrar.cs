using Autofac;
using Autofac.Core;
using Autofac.Integration.Mvc;
using cloudCommerce.Core.Data;
using cloudCommerce.Core.Infrastructure;
using cloudCommerce.Core.Infrastructure.DependencyManagement;
using cloudCommerce.Data;
using cloudCommerce.ShippingByWeight.Data;
using cloudCommerce.ShippingByWeight.Domain;
using cloudCommerce.ShippingByWeight.Services;

namespace cloudCommerce.ShippingByWeight
{
    public class DependencyRegistrar : IDependencyRegistrar
    {
		public virtual void Register(ContainerBuilder builder, ITypeFinder typeFinder, bool isActiveModule)
        {
			builder.RegisterType<ShippingByWeightService>().As<IShippingByWeightService>().InstancePerRequest();

            // data layer
            // register named context
            builder.Register<IDbContext>(c => new ShippingByWeightObjectContext(DataSettings.Current.DataConnectionString))
                .Named<IDbContext>(ShippingByWeightObjectContext.ALIASKEY)
                .InstancePerRequest();

			builder.Register<ShippingByWeightObjectContext>(c => new ShippingByWeightObjectContext(DataSettings.Current.DataConnectionString))
                .InstancePerRequest();

            // override required repository with our custom context
            builder.RegisterType<EfRepository<ShippingByWeightRecord>>()
                .As<IRepository<ShippingByWeightRecord>>()
                .WithParameter(ResolvedParameter.ForNamed<IDbContext>(ShippingByWeightObjectContext.ALIASKEY))
                .InstancePerRequest();
        }

        public int Order
        {
            get { return 1; }
        }
    }
}
