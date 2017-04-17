using FluentValidation;
using cloudCommerce.Admin.Models.Polls;
using cloudCommerce.Services.Localization;

namespace cloudCommerce.Admin.Validators.Polls
{
	public partial class PollAnswerValidator : AbstractValidator<PollAnswerModel>
    {
        public PollAnswerValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.Name)
                .NotNull()
                .WithMessage(localizationService.GetResource("Admin.ContentManagement.Polls.Answers.Fields.Name.Required"));
        }
    }
}