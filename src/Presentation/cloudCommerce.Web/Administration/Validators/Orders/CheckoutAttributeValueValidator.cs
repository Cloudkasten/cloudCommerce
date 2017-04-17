using FluentValidation;
using cloudCommerce.Admin.Models.Orders;
using cloudCommerce.Services.Localization;

namespace cloudCommerce.Admin.Validators.Orders
{
	public partial class CheckoutAttributeValueValidator : AbstractValidator<CheckoutAttributeValueModel>
    {
        public CheckoutAttributeValueValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.Name).NotNull().WithMessage(localizationService.GetResource("Admin.Catalog.Attributes.CheckoutAttributes.Values.Fields.Name.Required"));
        }
    }
}