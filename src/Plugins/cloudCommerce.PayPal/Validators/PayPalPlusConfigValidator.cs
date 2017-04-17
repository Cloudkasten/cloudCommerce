using System;
using FluentValidation;
using cloudCommerce.PayPal.Models;
using cloudCommerce.Services.Localization;
using cloudCommerce.Web.Framework.Validators;

namespace cloudCommerce.PayPal.Validators
{
	public class PayPalPlusConfigValidator : SmartValidatorBase<PayPalPlusConfigurationModel>
	{
		public PayPalPlusConfigValidator(ILocalizationService localize, Func<string, bool> addRule)
		{
			if (addRule("ClientId"))
			{
				RuleFor(x => x.ClientId).NotEmpty()
					.WithMessage(localize.GetResource("Plugins.cloudCommerce.PayPal.ValidateClientIdAndSecret"));
			}

			if (addRule("Secret"))
			{
				RuleFor(x => x.Secret).NotEmpty()
					.WithMessage(localize.GetResource("Plugins.cloudCommerce.PayPal.ValidateClientIdAndSecret"));
			}

			if (addRule("ThirdPartyPaymentMethods"))
			{
				RuleFor(x => x.ThirdPartyPaymentMethods)
					.Must(x => x.Count <= 5)
					.WithMessage(localize.GetResource("Plugins.Payments.PayPalPlus.ValidateThirdPartyPaymentMethods"));
			}
		}
	}
}