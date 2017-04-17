using FluentValidation;
using cloudCommerce.Admin.Models.Messages;
using cloudCommerce.Services.Localization;

namespace cloudCommerce.Admin.Validators.Messages
{
	public partial class NewsLetterSubscriptionValidator : AbstractValidator<NewsLetterSubscriptionModel>
    {
        public NewsLetterSubscriptionValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.Email).NotNull().WithMessage(localizationService.GetResource("Admin.Promotions.NewsLetterSubscriptions.Fields.Email.Required"));
            RuleFor(x => x.Email).EmailAddress().WithMessage(localizationService.GetResource("Admin.Common.WrongEmail"));
        }
    }
}