using FluentValidation;
using cloudCommerce.Admin.Models.Orders;
using cloudCommerce.Services.Localization;

namespace cloudCommerce.Admin.Validators.Orders
{
	public partial class CheckoutAttributeValidator : AbstractValidator<CheckoutAttributeModel>
    {
        public CheckoutAttributeValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.Name).NotNull().WithMessage(localizationService.GetResource("Admin.Catalog.Attributes.CheckoutAttributes.Fields.Name.Required"));
        }
    }
}