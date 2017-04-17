using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using FluentValidation.Attributes;
using cloudCommerce.Web.Framework;
using cloudCommerce.Web.Framework.Modelling;
using cloudCommerce.Web.Validators.Customer;

namespace cloudCommerce.Web.Models.Customer
{
    [Validator(typeof(ChangePasswordValidator))]
    public partial class ChangePasswordModel : ModelBase
    {
        [AllowHtml]
        [DataType(DataType.Password)]
        [SmartResourceDisplayName("Account.ChangePassword.Fields.OldPassword")]
        public string OldPassword { get; set; }

        [AllowHtml]
        [DataType(DataType.Password)]
        [SmartResourceDisplayName("Account.ChangePassword.Fields.NewPassword")]
        public string NewPassword { get; set; }

        [AllowHtml]
        [DataType(DataType.Password)]
        [SmartResourceDisplayName("Account.ChangePassword.Fields.ConfirmNewPassword")]
        public string ConfirmNewPassword { get; set; }

        public string Result { get; set; }

        public CustomerNavigationModel NavigationModel { get; set; }

    }
}