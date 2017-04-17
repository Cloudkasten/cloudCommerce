using FluentValidation;
using cloudCommerce.Admin.Models.Orders;
using cloudCommerce.Services.Localization;

namespace cloudCommerce.Admin.Validators.Orders
{
	public partial class RecurringPaymentValidator : AbstractValidator<RecurringPaymentModel>
    {
        public RecurringPaymentValidator(ILocalizationService localizationService)
        {
        }
    }
}