using FluentValidation;
using cloudCommerce.Admin.Models.Topics;
using cloudCommerce.Services.Localization;

namespace cloudCommerce.Admin.Validators.Topics
{
	public partial class TopicValidator : AbstractValidator<TopicModel>
    {
        public TopicValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.SystemName).NotNull().WithMessage(localizationService.GetResource("Admin.ContentManagement.Topics.Fields.SystemName.Required"));
        }
    }
}