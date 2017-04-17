using cloudCommerce.Core;
using cloudCommerce.WebApi.Models;
using Telerik.Web.Mvc;

namespace cloudCommerce.WebApi.Services
{
	public partial interface IWebApiPluginService
	{
		IPagedList<WebApiUserModel> GetUsers(int pageIndex, int pageSize);
		GridModel<WebApiUserModel> GetGridModel(int pageIndex, int pageSize);

		bool CreateKeys(int customerId);
		void RemoveKeys(int customerId);
		void EnableOrDisableUser(int customerId, bool enable);
	}
}
