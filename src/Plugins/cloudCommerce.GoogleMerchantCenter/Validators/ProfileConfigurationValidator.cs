using FluentValidation;
using cloudCommerce.GoogleMerchantCenter.Models;
using cloudCommerce.Services.Localization;

namespace cloudCommerce.GoogleMerchantCenter.Validators
{
	public class ProfileConfigurationValidator : AbstractValidator<ProfileConfigurationModel>
	{
		public ProfileConfigurationValidator(ILocalizationService localize)
        {
            RuleFor(x => x.ExpirationDays).InclusiveBetween(0, 29)
				.WithMessage(localize.GetResource("Plugins.Feed.Froogle.ExpirationDays.Validate"));
		}
	}
}
