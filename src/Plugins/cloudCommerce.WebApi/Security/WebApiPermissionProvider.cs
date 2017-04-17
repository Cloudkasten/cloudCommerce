using cloudCommerce.Core.Domain.Customers;
using cloudCommerce.Core.Domain.Security;
using cloudCommerce.Services.Security;
using System.Collections.Generic;

namespace cloudCommerce.WebApi.Security
{
	public partial class WebApiPermissionProvider : IPermissionProvider
	{
		public static readonly PermissionRecord ManageWebApi = new PermissionRecord { Name = "Plugins. Manage Web-API.", SystemName = "ManageWebApi", Category = "Plugin" };

		public virtual IEnumerable<PermissionRecord> GetPermissions()
		{
			return new[] { ManageWebApi };
		}

		public virtual IEnumerable<DefaultPermissionRecord> GetDefaultPermissions()
		{
			//return Enumerable.Empty<DefaultPermissionRecord>();

			//uncomment code below in order to give appropriate permissions to admin by default
			return new[] 
            {
                new DefaultPermissionRecord 
                {
                    CustomerRoleSystemName = SystemCustomerRoleNames.Administrators,
                    PermissionRecords = new[] { ManageWebApi }
                },
            };
		}
	}
}
