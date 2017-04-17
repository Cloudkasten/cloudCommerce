using FluentValidation;
using cloudCommerce.Services.Localization;
using cloudCommerce.Web.Models.PrivateMessages;

namespace cloudCommerce.Web.Validators.PrivateMessages
{
    public class SendPrivateMessageValidator : AbstractValidator<SendPrivateMessageModel>
    {
        public SendPrivateMessageValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.Subject).NotEmpty().WithMessage(localizationService.GetResource("PrivateMessages.SubjectCannotBeEmpty"));
            RuleFor(x => x.Message).NotEmpty().WithMessage(localizationService.GetResource("PrivateMessages.MessageCannotBeEmpty"));
        }
    }
}