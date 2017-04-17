using Autofac;
using Autofac.Integration.Mvc;
using cloudCommerce.Core.Infrastructure;
using cloudCommerce.Core.Infrastructure.DependencyManagement;
using cloudCommerce.WebApi.Services;

namespace cloudCommerce.WebApi
{
	public class DependencyRegistrar : IDependencyRegistrar
	{
		public virtual void Register(ContainerBuilder builder, ITypeFinder typeFinder, bool isActiveModule)
		{
			builder.RegisterType<WebApiPluginService>().As<IWebApiPluginService>().InstancePerRequest();
		}

		public int Order
		{
			get { return 1; }
		}
	}
}
