using System.Web.Mvc;
using cloudCommerce.AmazonPay.Models;
using cloudCommerce.AmazonPay.Services;
using cloudCommerce.Web.Framework.Controllers;

namespace cloudCommerce.AmazonPay.Controllers
{
	public abstract partial class AmazonPayControllerBase : PublicControllerBase
	{
		protected ActionResult GetActionResult(AmazonPayViewModel model)
		{
			switch (model.Result)
			{
				case AmazonPayResultType.None:
					return new EmptyResult();

				case AmazonPayResultType.PluginView:
					return View(model);

				case AmazonPayResultType.Unauthorized:
					return new HttpUnauthorizedResult();

				case AmazonPayResultType.Redirect:
				default:
					return RedirectToAction(model.RedirectAction, model.RedirectController, new { area = "" });
			}
		}
	}
}