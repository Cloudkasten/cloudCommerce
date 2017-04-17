using FluentValidation;
using cloudCommerce.Admin.Models.Discounts;
using cloudCommerce.Services.Localization;

namespace cloudCommerce.Admin.Validators.Discounts
{
	public partial class DiscountValidator : AbstractValidator<DiscountModel>
    {
        public DiscountValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.Name)
                .NotNull()
                .WithMessage(localizationService.GetResource("Admin.Promotions.Discounts.Fields.Name.Required"));
        }
    }
}