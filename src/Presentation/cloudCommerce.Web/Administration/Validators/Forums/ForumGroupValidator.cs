using FluentValidation;
using cloudCommerce.Admin.Models.Forums;
using cloudCommerce.Services.Localization;

namespace cloudCommerce.Admin.Validators.Forums
{
	public partial class ForumGroupValidator : AbstractValidator<ForumGroupModel>
    {
        public ForumGroupValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.Name).NotNull().WithMessage(localizationService.GetResource("Admin.ContentManagement.Forums.ForumGroup.Fields.Name.Required"));
        }
    }
}