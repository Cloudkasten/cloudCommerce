using System;
using System.Collections.Generic;
using System.Web.WebPages;

namespace cloudCommerce.Web.Framework.UI
{

    public interface IContentContainer
    {

        IDictionary<string, object> ContentHtmlAttributes
        {
            get;
        }

        HelperResult Content
        {
            get;
            set;
        }

    }

}
