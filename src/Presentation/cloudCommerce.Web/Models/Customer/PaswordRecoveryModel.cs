using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using FluentValidation.Attributes;
using cloudCommerce.Web.Framework;
using cloudCommerce.Web.Framework.Modelling;
using cloudCommerce.Web.Validators.Customer;

namespace cloudCommerce.Web.Models.Customer
{
	[Validator(typeof(PasswordRecoveryValidator))]
    public partial class PasswordRecoveryModel : ModelBase
    {
        [AllowHtml]
        [SmartResourceDisplayName("Account.PasswordRecovery.Email")]
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }

        public string Result { get; set; }
    }
}