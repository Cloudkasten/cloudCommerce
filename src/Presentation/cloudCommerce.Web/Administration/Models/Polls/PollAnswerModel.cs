using System.Web.Mvc;
using FluentValidation.Attributes;
using cloudCommerce.Admin.Validators.Polls;
using cloudCommerce.Web.Framework;
using cloudCommerce.Web.Framework.Modelling;

namespace cloudCommerce.Admin.Models.Polls
{
    [Validator(typeof(PollAnswerValidator))]
    public class PollAnswerModel : EntityModelBase
    {
        public int PollId { get; set; }

        [SmartResourceDisplayName("Admin.ContentManagement.Polls.Answers.Fields.Name")]
        [AllowHtml]
        public string Name { get; set; }

        [SmartResourceDisplayName("Admin.ContentManagement.Polls.Answers.Fields.NumberOfVotes")]
        public int NumberOfVotes { get; set; }

        [SmartResourceDisplayName("Admin.ContentManagement.Polls.Answers.Fields.DisplayOrder")]
        //we don't name it "DisplayOrder" because Telerik has a small bug 
        //"if we have one more editor with the same name on a page, it doesn't allow editing"
        //in our case it's pollAnswer.DisplayOrder
        public int DisplayOrder1 { get; set; }

    }
}