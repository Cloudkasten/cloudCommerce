using cloudCommerce.Core.Configuration;

namespace cloudCommerce.Web.Framework.WebApi
{
	public class WebApiSettings : ISettings
	{
		public int ValidMinutePeriod { get; set; }
		public bool LogUnauthorized { get; set; }
		public bool NoRequestTimestampValidation { get; set; }
		public bool AllowEmptyMd5Hash { get; set; }
	}
}
