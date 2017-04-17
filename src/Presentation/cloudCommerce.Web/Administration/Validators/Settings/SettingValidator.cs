using FluentValidation;
using cloudCommerce.Admin.Models.Settings;
using cloudCommerce.Services.Localization;

namespace cloudCommerce.Admin.Validators.Settings
{
	public partial class SettingValidator : AbstractValidator<SettingModel>
    {
        public SettingValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.Name).NotNull().WithMessage(localizationService.GetResource("Admin.Configuration.Settings.AllSettings.Fields.Name.Required"));
        }
    }
}