using System;
using System.Web.Mvc;
using cloudCommerce.Services.Pdf;

namespace cloudCommerce.Web.Framework.Pdf
{

	public class PdfPartialViewContent : PdfHtmlContent
	{
		public PdfPartialViewContent(string partialViewName, object model, ControllerContext controllerContext)
			: base(PdfViewContent.ViewToString(partialViewName, null, model, true, controllerContext, false))
		{
		}
	}

}
