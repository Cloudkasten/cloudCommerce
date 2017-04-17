using FluentValidation;
using cloudCommerce.Services.Localization;
using cloudCommerce.Web.Models.Customer;

namespace cloudCommerce.Web.Validators.Customer
{
    public class PasswordRecoveryValidator : AbstractValidator<PasswordRecoveryModel>
    {
        public PasswordRecoveryValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage(localizationService.GetResource("Account.PasswordRecovery.Email.Required"));
            RuleFor(x => x.Email).EmailAddress().WithMessage(localizationService.GetResource("Common.WrongEmail"));
        }}
}