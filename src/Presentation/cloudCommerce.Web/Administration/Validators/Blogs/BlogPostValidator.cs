using FluentValidation;
using cloudCommerce.Admin.Models.Blogs;
using cloudCommerce.Services.Localization;

namespace cloudCommerce.Admin.Validators.Blogs
{
    public partial class BlogPostValidator : AbstractValidator<BlogPostModel>
    {
        public BlogPostValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.Title)
                .NotNull()
                .WithMessage(localizationService.GetResource("Admin.ContentManagement.Blog.BlogPosts.Fields.Title.Required"));

            RuleFor(x => x.Body)
                .NotNull()
                .WithMessage(localizationService.GetResource("Admin.ContentManagement.Blog.BlogPosts.Fields.Body.Required"));
        }
    }
}