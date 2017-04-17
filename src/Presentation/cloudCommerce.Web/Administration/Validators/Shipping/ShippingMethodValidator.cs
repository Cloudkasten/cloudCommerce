using FluentValidation;
using cloudCommerce.Admin.Models.Shipping;
using cloudCommerce.Services.Localization;

namespace cloudCommerce.Admin.Validators.Shipping
{
	public partial class ShippingMethodValidator : AbstractValidator<ShippingMethodModel>
    {
        public ShippingMethodValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.Name).NotNull().WithMessage(localizationService.GetResource("Admin.Configuration.Shipping.Methods.Fields.Name.Required"));
        }
    }
}