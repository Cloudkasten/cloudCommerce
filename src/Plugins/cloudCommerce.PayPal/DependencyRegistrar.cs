using Autofac;
using Autofac.Integration.Mvc;
using cloudCommerce.Core.Infrastructure;
using cloudCommerce.Core.Infrastructure.DependencyManagement;
using cloudCommerce.PayPal.Filters;
using cloudCommerce.PayPal.Services;
using cloudCommerce.Web.Controllers;

namespace cloudCommerce.PayPal
{
	public class DependencyRegistrar : IDependencyRegistrar
	{
		public virtual void Register(ContainerBuilder builder, ITypeFinder typeFinder, bool isActiveModule)
		{
			builder.RegisterType<PayPalService>().As<IPayPalService>().InstancePerRequest();

			if (isActiveModule)
			{
				builder.RegisterType<PayPalExpressCheckoutFilter>().AsActionFilterFor<CheckoutController>(x => x.PaymentMethod()).InstancePerRequest();

				builder.RegisterType<PayPalExpressWidgetZoneFilter>().AsActionFilterFor<ShoppingCartController>(x => x.FlyoutShoppingCart()).InstancePerRequest();

				builder.RegisterType<PayPalPlusCheckoutFilter>()
					.AsActionFilterFor<CheckoutController>(x => x.PaymentMethod())
					.InstancePerRequest();

				builder.RegisterType<PayPalPlusWidgetZoneFilter>()
					.AsActionFilterFor<CheckoutController>(x => x.Completed())
					.InstancePerRequest();
			}
		}

		public int Order
		{
			get { return 1; }
		}
	}
}
