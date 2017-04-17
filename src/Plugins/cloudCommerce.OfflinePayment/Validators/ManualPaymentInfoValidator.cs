using FluentValidation;
using cloudCommerce.OfflinePayment.Models;
using cloudCommerce.Services.Localization;
using cloudCommerce.Web.Framework.Validators;

namespace cloudCommerce.OfflinePayment.Validators
{
    public class ManualPaymentInfoValidator : AbstractValidator<ManualPaymentInfoModel>
    {
		public ManualPaymentInfoValidator(ILocalizationService localizationService)
        {
            //useful links:
            //http://fluentvalidation.codeplex.com/wikipage?title=Custom&referringTitle=Documentation&ANCHOR#CustomValidator
            //http://benjii.me/2010/11/credit-card-validator-attribute-for-asp-net-mvc-3/

            RuleFor(x => x.CardholderName).NotEmpty().WithMessage(localizationService.GetResource("Payment.CardholderName.Required"));
            RuleFor(x => x.CardNumber).IsCreditCard().WithMessage(localizationService.GetResource("Payment.CardNumber.Wrong"));
            RuleFor(x => x.CardCode).Matches(@"^[0-9]{3,4}$").WithMessage(localizationService.GetResource("Payment.CardCode.Wrong"));
        }}
}