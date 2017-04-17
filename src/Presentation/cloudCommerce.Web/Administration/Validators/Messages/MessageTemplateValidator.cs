using FluentValidation;
using cloudCommerce.Admin.Models.Messages;
using cloudCommerce.Services.Localization;

namespace cloudCommerce.Admin.Validators.Messages
{
	public partial class MessageTemplateValidator : AbstractValidator<MessageTemplateModel>
    {
        public MessageTemplateValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.Subject).NotNull().WithMessage(localizationService.GetResource("Admin.ContentManagement.MessageTemplates.Fields.Subject.Required"));
            RuleFor(x => x.Body).NotNull().WithMessage(localizationService.GetResource("Admin.ContentManagement.MessageTemplates.Fields.Body.Required"));
        }
    }
}