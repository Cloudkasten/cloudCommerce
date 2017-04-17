using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;
using cloudCommerce.Core.Domain.Orders;
using cloudCommerce.Core.Domain.Payments;
using cloudCommerce.Core.Domain.Stores;
using cloudCommerce.PayPal.Settings;
using cloudCommerce.Services.Payments;

namespace cloudCommerce.PayPal.Services
{
	public interface IPayPalService
	{
		void AddOrderNote(PayPalSettingsBase settings, Order order, string anyString, bool isIpn = false);

		void LogError(Exception exception, string shortMessage = null, string fullMessage = null, bool notify = false, IList<string> errors = null, bool isWarning = false);

		PayPalPaymentInstruction ParsePaymentInstruction(dynamic json);

		string CreatePaymentInstruction(PayPalPaymentInstruction instruct);

		PaymentStatus GetPaymentStatus(string state, string reasonCode, PaymentStatus defaultStatus);

		PayPalResponse CallApi(string method, string path, string accessToken, PayPalApiSettingsBase settings, string data);

		PayPalResponse EnsureAccessToken(PayPalSessionData session, PayPalApiSettingsBase settings);

		PayPalResponse GetPayment(PayPalApiSettingsBase settings, PayPalSessionData session);

		PayPalResponse CreatePayment(
			PayPalApiSettingsBase settings,
			PayPalSessionData session,
			List<OrganizedShoppingCartItem> cart,
			string providerSystemName,
			string returnUrl,
			string cancelUrl);

		PayPalResponse ExecutePayment(PayPalApiSettingsBase settings, PayPalSessionData session);

		PayPalResponse Refund(PayPalApiSettingsBase settings, PayPalSessionData session, RefundPaymentRequest request);

		PayPalResponse Capture(PayPalApiSettingsBase settings, PayPalSessionData session, CapturePaymentRequest request);

		PayPalResponse Void(PayPalApiSettingsBase settings, PayPalSessionData session, VoidPaymentRequest request);

		PayPalResponse UpsertCheckoutExperience(PayPalApiSettingsBase settings, PayPalSessionData session, Store store);

		PayPalResponse DeleteCheckoutExperience(PayPalApiSettingsBase settings, PayPalSessionData session);

		PayPalResponse CreateWebhook(PayPalApiSettingsBase settings, PayPalSessionData session, string url);

		PayPalResponse DeleteWebhook(PayPalApiSettingsBase settings, PayPalSessionData session);

		HttpStatusCode ProcessWebhook(
			PayPalApiSettingsBase settings,
			NameValueCollection headers,
			string rawJson,
			string providerSystemName);
	}
}