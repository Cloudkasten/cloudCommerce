using System.Collections.Generic;
using cloudCommerce.Core.Domain.Security;

namespace cloudCommerce.Services.Security
{
    public interface IPermissionProvider
    {
        IEnumerable<PermissionRecord> GetPermissions();
        IEnumerable<DefaultPermissionRecord> GetDefaultPermissions();
    }
}
