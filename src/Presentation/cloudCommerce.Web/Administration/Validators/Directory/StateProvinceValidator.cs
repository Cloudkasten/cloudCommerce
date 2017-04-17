using FluentValidation;
using cloudCommerce.Admin.Models.Directory;
using cloudCommerce.Services.Localization;

namespace cloudCommerce.Admin.Validators.Directory
{
	public partial class StateProvinceValidator : AbstractValidator<StateProvinceModel>
    {
        public StateProvinceValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.Name)
                .NotNull()
                .WithMessage(localizationService.GetResource("Admin.Configuration.Countries.States.Fields.Name.Required"));
        }
    }
}