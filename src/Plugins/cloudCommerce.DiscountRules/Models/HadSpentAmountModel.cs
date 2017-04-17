using cloudCommerce.Web.Framework;

namespace cloudCommerce.DiscountRules.Models
{
	public class HadSpentAmountModel : DiscountRuleModelBase
    {
		[SmartResourceDisplayName("Plugins.DiscountRules.HadSpentAmount.Fields.Amount")]
		public decimal SpentAmount { get; set; }

		[SmartResourceDisplayName("Plugins.DiscountRules.HadSpentAmount.Fields.LimitToCurrentBasketSubTotal")]
		public bool LimitToCurrentBasketSubTotal { get; set; }
    }
}