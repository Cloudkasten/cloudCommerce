using cloudCommerce.Web.Framework;
using cloudCommerce.Web.Framework.Modelling;

namespace cloudCommerce.Admin.Models.ShoppingCart
{
    public class ShoppingCartModel : ModelBase
    {
        [SmartResourceDisplayName("Admin.CurrentCarts.Customer")]
        public int CustomerId { get; set; }
        [SmartResourceDisplayName("Admin.CurrentCarts.Customer")]
        public string CustomerEmail { get; set; }

        [SmartResourceDisplayName("Admin.CurrentCarts.TotalItems")]
        public int TotalItems { get; set; }
    }
}