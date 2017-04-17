using cloudCommerce.Web.Framework.WebApi.Security;
using System.Web.Http;

namespace cloudCommerce.WebApi.Controllers.Api
{
	[WebApiAuthenticate]
	public class HomeController : ApiController
	{
	}
}
