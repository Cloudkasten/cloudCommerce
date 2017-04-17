using FluentValidation;
using cloudCommerce.Admin.Models.Common;
using cloudCommerce.Services.Localization;

namespace cloudCommerce.Admin.Validators.Localization
{
	public partial class GenericAttributeValidator : AbstractValidator<GenericAttributeModel>
    {
        public GenericAttributeValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.Key).NotEmpty().WithMessage(localizationService.GetResource("Admin.Common.GenericAttributes.Fields.Name.Required"));
        }
    }
}