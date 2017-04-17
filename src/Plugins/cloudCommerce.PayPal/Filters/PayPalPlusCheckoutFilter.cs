using System.Web.Mvc;
using System.Web.Routing;
using cloudCommerce.Services;
using cloudCommerce.Services.Payments;

namespace cloudCommerce.PayPal.Filters
{
	public class PayPalPlusCheckoutFilter : IActionFilter
	{
		private readonly ICommonServices _services;
		private readonly IPaymentService _paymentService;

		public PayPalPlusCheckoutFilter(
			ICommonServices services,
			IPaymentService paymentService)
		{
			_services = services;
			_paymentService = paymentService;
		}

		public void OnActionExecuting(ActionExecutingContext filterContext)
		{
			if (filterContext == null || filterContext.ActionDescriptor == null || filterContext.HttpContext == null || filterContext.HttpContext.Request == null)
				return;

			var store = _services.StoreContext.CurrentStore;

			if (!_paymentService.IsPaymentMethodActive(PayPalPlusProvider.SystemName, store.Id))
				return;

			var routeValues = new RouteValueDictionary(new { action = "PaymentWall", controller = "PayPalPlus" });

			filterContext.Result = new RedirectToRouteResult("cloudCommerce.PayPalPlus", routeValues);
		}

		public void OnActionExecuted(ActionExecutedContext filterContext)
		{

		}
	}
}