using System.Linq;
using cloudCommerce.AmazonPay.Services;
using cloudCommerce.Core.Domain.Messages;
using cloudCommerce.Core.Events;
using cloudCommerce.Core.Plugins;
using cloudCommerce.Services;
using cloudCommerce.Services.Messages;
using cloudCommerce.Services.Orders;
using cloudCommerce.Web.Framework;

namespace cloudCommerce.AmazonPay.Events
{
	public class MessageTokenEventConsumer : IConsumer<MessageTokensAddedEvent<Token>>
	{
		private readonly IPluginFinder _pluginFinder;
		private readonly ICommonServices _services;
		private readonly IOrderService _orderService;

		public MessageTokenEventConsumer(
			IPluginFinder pluginFinder,
			ICommonServices services,
			IOrderService orderService)
		{
			_pluginFinder = pluginFinder;
			_services = services;
			_orderService = orderService;
		}

		public void HandleEvent(MessageTokensAddedEvent<Token> messageTokenEvent)
		{
			if (!messageTokenEvent.Message.Name.IsCaseInsensitiveEqual("OrderPlaced.CustomerNotification"))
				return;

			var storeId = _services.StoreContext.CurrentStore.Id;

			if (!_pluginFinder.IsPluginReady(_services.Settings, AmazonPayCore.SystemName, storeId))
				return;

			var order = _orderService.SearchOrders(storeId, _services.WorkContext.CurrentCustomer.Id, null, null, null, null, null, null, null, null, 0, 1).FirstOrDefault();

			var isAmazonPayment = (order != null && order.PaymentMethodSystemName.IsCaseInsensitiveEqual(AmazonPayCore.SystemName));
			var tokenValue = (isAmazonPayment ? _services.Localization.GetResource("Plugins.Payments.AmazonPay.BillingAddressMessageNote") : "");

			messageTokenEvent.Tokens.Add(new Token("cloudCommerce.AmazonPay.BillingAddressMessageNote", tokenValue));
		}
	}
}