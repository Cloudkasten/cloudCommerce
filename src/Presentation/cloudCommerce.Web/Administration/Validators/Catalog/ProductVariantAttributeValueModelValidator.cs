using FluentValidation;
using cloudCommerce.Core.Domain.Catalog;
using cloudCommerce.Admin.Models.Catalog;
using cloudCommerce.Services.Localization;

namespace cloudCommerce.Admin.Validators.Catalog
{
	public partial class ProductVariantAttributeValueModelValidator : AbstractValidator<ProductModel.ProductVariantAttributeValueModel>
    {
        public ProductVariantAttributeValueModelValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(
				localizationService.GetResource("Admin.Catalog.Products.ProductVariantAttributes.Attributes.Values.Fields.Name.Required")
			);

			RuleFor(x => x.Quantity).GreaterThanOrEqualTo(1).WithMessage(
				localizationService.GetResource("Admin.Catalog.Products.ProductVariantAttributes.Attributes.Values.Fields.Quantity.GreaterOrEqualToOne")
			)
			.When(x => x.ValueTypeId == (int)ProductVariantAttributeValueType.ProductLinkage);
        }
    }
}