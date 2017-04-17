using System;
using System.Globalization;
using FluentValidation;
using cloudCommerce.Admin.Models.Directory;
using cloudCommerce.Services.Localization;

namespace cloudCommerce.Admin.Validators.Directory
{
	public partial class DeliveryTimeValidator : AbstractValidator<DeliveryTimeModel>
    {
        public DeliveryTimeValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage(localizationService.GetResource("Admin.Configuration.DeliveryTimes.Fields.Name.Required"))
                .Length(1, 50).WithMessage(localizationService.GetResource("Admin.Configuration.DeliveryTimes.Fields.Name.Range"));
            RuleFor(x => x.ColorHexValue)
                .NotEmpty().WithMessage(localizationService.GetResource("Admin.Configuration.DeliveryTimes.Fields.ColorHexValue.Required"))
                .Length(1, 50).WithMessage(localizationService.GetResource("Admin.Configuration.DeliveryTimes.Fields.ColorHexValue.Range"));
            RuleFor(x => x.DisplayLocale)
                .Must(x =>
                {
                    try
                    {
                        if (String.IsNullOrEmpty(x))
                            return true;
                        var culture = new CultureInfo(x);
                        return culture != null;
                    }
                    catch
                    {
                        return false;
                    }
                })
                .WithMessage(localizationService.GetResource("Admin.Configuration.DeliveryTimes.Fields.DisplayLocale.Validation"));
        }
    }
}