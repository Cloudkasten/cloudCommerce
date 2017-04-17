using System.Net;
using System.Web;
using cloudCommerce.PayPal.Services;
using cloudCommerce.PayPal.Settings;
using cloudCommerce.Services.Orders;

namespace cloudCommerce.PayPal
{
	internal static class MiscExtensions
	{
		public static string GetPayPalUrl(this PayPalSettingsBase settings)
		{
			return settings.UseSandbox ?
				"https://www.sandbox.paypal.com/cgi-bin/webscr" :
				"https://www.paypal.com/cgi-bin/webscr";
		}

		public static HttpWebRequest GetPayPalWebRequest(this PayPalSettingsBase settings)
		{
			if (settings.SecurityProtocol.HasValue)
			{
				ServicePointManager.SecurityProtocol = settings.SecurityProtocol.Value;
			}

			var request = (HttpWebRequest)WebRequest.Create(GetPayPalUrl(settings));
			return request;
		}

		public static PayPalSessionData GetPayPalSessionData(this HttpContextBase httpContext, CheckoutState state = null)
		{
			if (state == null)
				state = httpContext.GetCheckoutState();

			if (!state.CustomProperties.ContainsKey(PayPalPlusProvider.SystemName))
				state.CustomProperties.Add(PayPalPlusProvider.SystemName, new PayPalSessionData());

			return state.CustomProperties[PayPalPlusProvider.SystemName] as PayPalSessionData;
		}
	}
}