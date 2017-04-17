using FluentValidation;
using cloudCommerce.Admin.Models.Catalog;
using cloudCommerce.Services.Localization;

namespace cloudCommerce.Admin.Validators.Catalog
{
	public partial class ProductReviewValidator : AbstractValidator<ProductReviewModel>
    {
        public ProductReviewValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage(localizationService.GetResource("Admin.Catalog.ProductReviews.Fields.Title.Required"));
            RuleFor(x => x.ReviewText).NotEmpty().WithMessage(localizationService.GetResource("Admin.Catalog.ProductReviews.Fields.ReviewText.Required"));
        }}
}