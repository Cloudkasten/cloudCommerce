using Autofac;
using Autofac.Core;
using cloudCommerce.Core.Data;
using cloudCommerce.Core.Infrastructure;
using cloudCommerce.Core.Infrastructure.DependencyManagement;
using cloudCommerce.Data;
using cloudCommerce.GoogleMerchantCenter.Data;
using cloudCommerce.GoogleMerchantCenter.Domain;
using cloudCommerce.GoogleMerchantCenter.Services;

namespace cloudCommerce.GoogleMerchantCenter
{
    public class DependencyRegistrar : IDependencyRegistrar
    {
		public virtual void Register(ContainerBuilder builder, ITypeFinder typeFinder, bool isActiveModule)
        {
            builder.RegisterType<GoogleFeedService>().As<IGoogleFeedService>().InstancePerRequest();

            //register named context
			builder.Register<IDbContext>(c => new GoogleProductObjectContext(DataSettings.Current.DataConnectionString))
                .Named<IDbContext>(GoogleProductObjectContext.ALIASKEY)
                .InstancePerRequest();

			builder.Register<GoogleProductObjectContext>(c => new GoogleProductObjectContext(DataSettings.Current.DataConnectionString))
                .InstancePerRequest();

            //override required repository with our custom context
            builder.RegisterType<EfRepository<GoogleProductRecord>>()
                .As<IRepository<GoogleProductRecord>>()
                .WithParameter(ResolvedParameter.ForNamed<IDbContext>(GoogleProductObjectContext.ALIASKEY))
                .InstancePerRequest();
        }

        public int Order
        {
            get { return 1; }
        }
    }
}
