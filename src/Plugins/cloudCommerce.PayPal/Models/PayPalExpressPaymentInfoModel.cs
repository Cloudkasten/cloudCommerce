using cloudCommerce.Web.Framework.Modelling;

namespace cloudCommerce.PayPal.Models
{
    public class PayPalExpressPaymentInfoModel : ModelBase
    {
        public PayPalExpressPaymentInfoModel()
        {
            
        }

        public bool CurrentPageIsBasket { get; set; }

        public string SubmitButtonImageUrl { get; set; }

    }
}