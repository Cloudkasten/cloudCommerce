using FluentValidation;
using cloudCommerce.Admin.Models.Plugins;
using cloudCommerce.Services.Localization;

namespace cloudCommerce.Admin.Validators.Plugins
{
	public partial class PluginValidator : AbstractValidator<PluginModel>
    {
        public PluginValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.FriendlyName).NotNull().WithMessage(localizationService.GetResource("Admin.Configuration.Plugins.Fields.FriendlyName.Required"));
        }
    }
}