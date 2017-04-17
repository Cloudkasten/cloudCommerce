using FluentValidation;
using cloudCommerce.Admin.Models.Settings;
using cloudCommerce.Core.Domain.Orders;
using cloudCommerce.Services.Localization;

namespace cloudCommerce.Admin.Validators.Settings
{
	public partial class OrderSettingsValidator : AbstractValidator<OrderSettingsModel>
    {
        public OrderSettingsValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.GiftCards_Activated_OrderStatusId).NotEqual((int)OrderStatus.Pending)
                .WithMessage(localizationService.GetResource("Admin.Configuration.Settings.RewardPoints.PointsForPurchases_Awarded.Pending"));

            RuleFor(x => x.GiftCards_Deactivated_OrderStatusId).NotEqual((int)OrderStatus.Pending)
                .WithMessage(localizationService.GetResource("Admin.Configuration.Settings.RewardPoints.PointsForPurchases_Canceled.Pending"));

			RuleFor(x => x.OrderListPageSize)
				.GreaterThan(0)
				.WithMessage(localizationService.GetResource("Admin.Validation.ValueGreaterZero"));
		}
    }
}