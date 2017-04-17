using System;
using System.Web;
using System.Web.Mvc;

namespace cloudCommerce.Core.Events
{
	/// <summary>
	/// to register global filters in Application_Start
	/// </summary>
	public class AppRegisterGlobalFiltersEvent
	{
		public GlobalFilterCollection Filters { get; set; }
	}
}
