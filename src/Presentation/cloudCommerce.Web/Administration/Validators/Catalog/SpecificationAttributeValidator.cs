using FluentValidation;
using cloudCommerce.Admin.Models.Catalog;
using cloudCommerce.Services.Localization;

namespace cloudCommerce.Admin.Validators.Catalog
{
	public partial class SpecificationAttributeValidator : AbstractValidator<SpecificationAttributeModel>
    {
        public SpecificationAttributeValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.Name).NotNull().WithMessage(localizationService.GetResource("Admin.Catalog.Attributes.SpecificationAttributes.Fields.Name.Required"));
        }
    }
}