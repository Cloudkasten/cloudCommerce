using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using FluentValidation.Attributes;
using cloudCommerce.Web.Framework;
using cloudCommerce.Web.Framework.Modelling;
using cloudCommerce.Web.Validators.Customer;

namespace cloudCommerce.Web.Models.Customer
{
    [Validator(typeof(PasswordRecoveryConfirmValidator))]
    public partial class PasswordRecoveryConfirmModel : ModelBase
    {
        [AllowHtml]
        [DataType(DataType.Password)]
        [SmartResourceDisplayName("Account.PasswordRecovery.NewPassword")]
        public string NewPassword { get; set; }

        [AllowHtml]
        [DataType(DataType.Password)]
        [SmartResourceDisplayName("Account.PasswordRecovery.ConfirmNewPassword")]
        public string ConfirmNewPassword { get; set; }

        public bool SuccessfullyChanged { get; set; }
        public string Result { get; set; }
    }
}