using FluentValidation;
using cloudCommerce.Admin.Models.Catalog;
using cloudCommerce.Services.Localization;

namespace cloudCommerce.Admin.Validators.Catalog
{
	public partial class ManufacturerValidator : AbstractValidator<ManufacturerModel>
    {
        public ManufacturerValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.Name).NotNull().WithMessage(localizationService.GetResource("Admin.Catalog.Manufacturers.Fields.Name.Required"));
        }
    }
}