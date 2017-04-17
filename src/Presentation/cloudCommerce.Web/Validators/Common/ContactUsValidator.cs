using FluentValidation;
using cloudCommerce.Services.Localization;
using cloudCommerce.Web.Models.Common;

namespace cloudCommerce.Web.Validators.Common
{
    public class ContactUsValidator : AbstractValidator<ContactUsModel>
    {
        public ContactUsValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.PrivacyAgreement)
                .Must(x => x == true)
                .WithMessage(localizationService.GetResource("ContactUs.PrivacyAgreement.MustBeAccepted"))
                .When(x => x.DisplayPrivacyAgreement == true);

            RuleFor(x => x.Email).NotEmpty().WithMessage(localizationService.GetResource("ContactUs.Email.Required"));
            RuleFor(x => x.Email).EmailAddress().WithMessage(localizationService.GetResource("Common.WrongEmail"));
            RuleFor(x => x.FullName).NotEmpty().WithMessage(localizationService.GetResource("ContactUs.FullName.Required"));
            RuleFor(x => x.Enquiry).NotEmpty().WithMessage(localizationService.GetResource("ContactUs.Enquiry.Required"));
        }}
}