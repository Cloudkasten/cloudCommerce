using FluentValidation;
using cloudCommerce.Admin.Models.Polls;
using cloudCommerce.Services.Localization;

namespace cloudCommerce.Admin.Validators.Polls
{
	public partial class PollValidator : AbstractValidator<PollModel>
    {
        public PollValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.Name)
                .NotNull()
                .WithMessage(localizationService.GetResource("Admin.ContentManagement.Polls.Fields.Name.Required"));
        }
    }
}