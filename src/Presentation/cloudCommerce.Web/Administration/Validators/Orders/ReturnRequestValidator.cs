using FluentValidation;
using cloudCommerce.Admin.Models.Orders;
using cloudCommerce.Services.Localization;

namespace cloudCommerce.Admin.Validators.Orders
{
	public partial class ReturnRequestValidator : AbstractValidator<ReturnRequestModel>
    {
        public ReturnRequestValidator(ILocalizationService localizationService)
        {
        }
    }
}