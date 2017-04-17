using Autofac;
using Autofac.Integration.Mvc;
using cloudCommerce.Core.Infrastructure;
using cloudCommerce.Core.Infrastructure.DependencyManagement;
using cloudCommerce.Core.Plugins;
using cloudCommerce.AmazonPay.Api;
using cloudCommerce.AmazonPay.Filters;
using cloudCommerce.AmazonPay.Services;
using cloudCommerce.Web.Controllers;

namespace cloudCommerce.AmazonPay
{
	public class DependencyRegistrar : IDependencyRegistrar
	{
		public virtual void Register(ContainerBuilder builder, ITypeFinder typeFinder, bool isActiveModule)
		{
			builder.RegisterType<AmazonPayService>().As<IAmazonPayService>().InstancePerRequest();
			builder.RegisterType<AmazonPayApi>().As<IAmazonPayApi>().InstancePerRequest();

			if (isActiveModule)
			{
				builder.RegisterType<AmazonPayCheckoutFilter>().AsActionFilterFor<CheckoutController>().InstancePerRequest();
			}
		}

		public int Order
		{
			get { return 1; }
		}
	}
}
