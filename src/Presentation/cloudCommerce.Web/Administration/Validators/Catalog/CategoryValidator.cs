using FluentValidation;
using cloudCommerce.Admin.Models.Catalog;
using cloudCommerce.Services.Localization;

namespace cloudCommerce.Admin.Validators.Catalog
{
	public partial class CategoryValidator : AbstractValidator<CategoryModel>
    {
        public CategoryValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.Name).NotNull().WithMessage(localizationService.GetResource("Admin.Catalog.Categories.Fields.Name.Required"));
        }
    }
}