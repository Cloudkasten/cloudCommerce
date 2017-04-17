using FluentValidation;
using cloudCommerce.Admin.Models.Customers;
using cloudCommerce.Services.Localization;

namespace cloudCommerce.Admin.Validators.Customers
{
	public partial class CustomerRoleValidator : AbstractValidator<CustomerRoleModel>
    {
        public CustomerRoleValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.Name).NotNull().WithMessage(localizationService.GetResource("Admin.Customers.CustomerRoles.Fields.Name.Required"));
        }
    }
}