using System.Web.Mvc;
using FluentValidation.Attributes;
using cloudCommerce.Web.Framework.Modelling;
using cloudCommerce.Web.Validators.PrivateMessages;

namespace cloudCommerce.Web.Models.PrivateMessages
{
    [Validator(typeof(SendPrivateMessageValidator))]
    public partial class SendPrivateMessageModel : EntityModelBase
    {
        public int ToCustomerId { get; set; }
        public string CustomerToName { get; set; }
        public bool AllowViewingToProfile { get; set; }

        public int ReplyToMessageId { get; set; }

        [AllowHtml]
        public string Subject { get; set; }

        [AllowHtml]
        public string Message { get; set; }
    }
}