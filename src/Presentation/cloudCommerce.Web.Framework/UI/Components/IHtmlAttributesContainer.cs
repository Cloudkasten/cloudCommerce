using System;
using System.Collections.Generic;

namespace cloudCommerce.Web.Framework.UI
{

    public interface IHtmlAttributesContainer
    {

        IDictionary<string, object> HtmlAttributes
        {
            get;
        }

    }

}
