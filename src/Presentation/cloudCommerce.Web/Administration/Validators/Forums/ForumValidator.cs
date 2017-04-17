using FluentValidation;
using cloudCommerce.Admin.Models.Forums;
using cloudCommerce.Services.Localization;

namespace cloudCommerce.Admin.Validators.Forums
{
	public partial class ForumValidator : AbstractValidator<ForumModel>
    {
        public ForumValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.Name).NotNull().WithMessage(localizationService.GetResource("Admin.ContentManagement.Forums.Forum.Fields.Name.Required"));
            RuleFor(x => x.ForumGroupId).NotEmpty().WithMessage(localizationService.GetResource("Admin.ContentManagement.Forums.Forum.Fields.ForumGroupId.Required"));
        }
    }
}