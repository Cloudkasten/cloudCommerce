using FluentValidation;
using cloudCommerce.Admin.Models.Messages;
using cloudCommerce.Services.Localization;

namespace cloudCommerce.Admin.Validators.Messages
{
	public partial class EmailAccountValidator : AbstractValidator<EmailAccountModel>
    {
        public EmailAccountValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.Email).NotEmpty();
            RuleFor(x => x.Email).EmailAddress().WithMessage(localizationService.GetResource("Admin.Common.WrongEmail"));
            
            RuleFor(x => x.DisplayName).NotEmpty();
        }
    }
}