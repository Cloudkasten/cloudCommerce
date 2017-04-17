using FluentValidation;
using cloudCommerce.Admin.Models.Tax;
using cloudCommerce.Services.Localization;

namespace cloudCommerce.Admin.Validators.Tax
{
	public partial class TaxCategoryValidator : AbstractValidator<TaxCategoryModel>
    {
        public TaxCategoryValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.Name).NotNull().WithMessage(localizationService.GetResource("Admin.Configuration.Tax.Categories.Fields.Name.Required"));
        }
    }
}