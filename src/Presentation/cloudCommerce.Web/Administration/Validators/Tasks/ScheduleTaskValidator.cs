using FluentValidation;
using cloudCommerce.Admin.Models.Directory;
using cloudCommerce.Admin.Models.Tasks;
using cloudCommerce.Services.Localization;
using cloudCommerce.Services.Tasks;

namespace cloudCommerce.Admin.Validators.Tasks
{
	public partial class ScheduleTaskValidator : AbstractValidator<ScheduleTaskModel>
    {
        public ScheduleTaskValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("Admin.System.ScheduleTasks.Name.Required"));
			RuleFor(x => x.CronExpression).Must(x => CronExpression.IsValid(x)).WithMessage(localizationService.GetResource("Admin.System.ScheduleTasks.InvalidCronExpression"));
        }
    }
}