using FluentValidation;
using cloudCommerce.PayPal.Models;
using cloudCommerce.Services.Localization;
using cloudCommerce.Web.Framework.Validators;

namespace cloudCommerce.PayPal.Validators
{
	public class PayPalExpressPaymentInfoValidator : AbstractValidator<PayPalExpressPaymentInfoModel>
	{
		public PayPalExpressPaymentInfoValidator(ILocalizationService localizationService) {

		}
	}
}