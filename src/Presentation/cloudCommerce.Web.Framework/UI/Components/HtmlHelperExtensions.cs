using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace cloudCommerce.Web.Framework.UI
{

    public static class HtmlHelperExtensions
    {

        public static ComponentFactory cloudCommerce(this HtmlHelper helper)
        {
            return new ComponentFactory(helper);
        }

    }

}
