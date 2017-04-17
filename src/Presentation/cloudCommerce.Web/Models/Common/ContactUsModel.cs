using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using FluentValidation.Attributes;
using cloudCommerce.Web.Framework;
using cloudCommerce.Web.Framework.Modelling;
using cloudCommerce.Web.Validators.Common;

namespace cloudCommerce.Web.Models.Common
{
	[Validator(typeof(ContactUsValidator))]
    public partial class ContactUsModel : ModelBase
    {
        [SmartResourceDisplayName("ContactUs.PrivacyAgreement")]
        public bool PrivacyAgreement { get; set; }

        public bool DisplayPrivacyAgreement { get; set; }

        [AllowHtml]
        [SmartResourceDisplayName("ContactUs.Email")]
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }

        [AllowHtml]
        [SmartResourceDisplayName("ContactUs.Enquiry")]
        public string Enquiry { get; set; }

        [AllowHtml]
        [SmartResourceDisplayName("ContactUs.FullName")]
        public string FullName { get; set; }

        public bool SuccessfullySent { get; set; }
        public string Result { get; set; }

        public bool DisplayCaptcha { get; set; }
    }
}