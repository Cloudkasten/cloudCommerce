using FluentValidation;
using cloudCommerce.Admin.Models.Localization;
using cloudCommerce.Services.Localization;

namespace cloudCommerce.Admin.Validators.Localization
{
	public partial class LanguageResourceValidator : AbstractValidator<LanguageResourceModel>
    {
        public LanguageResourceValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.Name).NotNull().WithMessage(localizationService.GetResource("Admin.Configuration.Languages.Resources.Fields.Name.Required"));
            RuleFor(x => x.Value).NotNull().WithMessage(localizationService.GetResource("Admin.Configuration.Languages.Resources.Fields.Value.Required"));
        }
    }
}