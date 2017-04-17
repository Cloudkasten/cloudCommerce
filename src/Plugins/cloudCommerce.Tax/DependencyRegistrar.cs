using Autofac;
using Autofac.Core;
using cloudCommerce.Core.Data;
using cloudCommerce.Core.Infrastructure;
using cloudCommerce.Core.Infrastructure.DependencyManagement;
using cloudCommerce.Data;
using cloudCommerce.Tax.Data;
using cloudCommerce.Tax.Domain;
using cloudCommerce.Tax.Services;

namespace cloudCommerce.Tax
{
    public class DependencyRegistrar : IDependencyRegistrar
    {
		public virtual void Register(ContainerBuilder builder, ITypeFinder typeFinder, bool isActiveModule)
        {
			builder.RegisterType<TaxRateService>().As<ITaxRateService>().InstancePerRequest();

			//register named context
			builder.Register<IDbContext>(c => new TaxRateObjectContext(DataSettings.Current.DataConnectionString))
				.Named<IDbContext>(TaxRateObjectContext.ALIASKEY)
				.InstancePerRequest();

			builder.Register<TaxRateObjectContext>(c => new TaxRateObjectContext(DataSettings.Current.DataConnectionString))
				.InstancePerRequest();

            //override required repository with our custom context
            builder.RegisterType<EfRepository<TaxRate>>()
                .As<IRepository<TaxRate>>()
                .WithParameter(ResolvedParameter.ForNamed<IDbContext>(TaxRateObjectContext.ALIASKEY))
                .InstancePerRequest();
        }

        public int Order
        {
            get { return 1; }
        }
    }
}
