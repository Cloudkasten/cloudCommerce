using FluentValidation;
using cloudCommerce.Services.Localization;
using cloudCommerce.Web.Models.Catalog;

namespace cloudCommerce.Web.Validators.Catalog
{
    public class ProductAskQuestionValidator : AbstractValidator<ProductAskQuestionModel>
    {
        public ProductAskQuestionValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.SenderEmail).NotEmpty().WithMessage(localizationService.GetResource("Account.Fields.Email.Required"));
            RuleFor(x => x.SenderEmail).EmailAddress().WithMessage(localizationService.GetResource("Common.WrongEmail"));

            RuleFor(x => x.SenderName).NotEmpty().WithMessage(localizationService.GetResource("Account.Fields.FullName.Required"));

            RuleFor(x => x.Question).NotEmpty().WithMessage(localizationService.GetResource("Products.AskQuestion.Question.Required"));
        }}
}