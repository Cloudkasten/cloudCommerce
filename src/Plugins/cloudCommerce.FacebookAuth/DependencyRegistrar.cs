using Autofac;
using cloudCommerce.Core.Infrastructure;
using cloudCommerce.Core.Infrastructure.DependencyManagement;
using cloudCommerce.FacebookAuth.Core;

namespace cloudCommerce.FacebookAuth
{
    public class DependencyRegistrar : IDependencyRegistrar
    {
		public virtual void Register(ContainerBuilder builder, ITypeFinder typeFinder, bool isActiveModule)
        {
            builder.RegisterType<FacebookProviderAuthorizer>().As<IOAuthProviderFacebookAuthorizer>().InstancePerRequest();
        }

        public int Order
        {
            get { return 1; }
        }
    }
}
