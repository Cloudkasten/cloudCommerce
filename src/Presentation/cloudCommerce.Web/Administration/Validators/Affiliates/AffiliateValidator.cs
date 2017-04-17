using FluentValidation;
using cloudCommerce.Admin.Models.Affiliates;
using cloudCommerce.Services.Localization;

namespace cloudCommerce.Admin.Validators.Affiliates
{
    public partial class AffiliateValidator : AbstractValidator<AffiliateModel>
    {
        public AffiliateValidator(ILocalizationService localizationService)
        {
        }
    }
}