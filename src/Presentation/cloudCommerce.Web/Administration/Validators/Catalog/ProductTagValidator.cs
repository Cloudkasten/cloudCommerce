using FluentValidation;
using cloudCommerce.Admin.Models.Catalog;
using cloudCommerce.Services.Localization;

namespace cloudCommerce.Admin.Validators.Catalog
{
	public partial class ProductTagValidator : AbstractValidator<ProductTagModel>
    {
        public ProductTagValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("Admin.Catalog.ProductTags.Fields.Name.Required"));
        }
    }
}