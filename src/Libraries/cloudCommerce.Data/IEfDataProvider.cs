using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using cloudCommerce.Core.Data;

namespace cloudCommerce.Data
{
    public interface IEfDataProvider : IDataProvider
    {
        /// <summary>
        /// Get connection factory
        /// </summary>
        /// <returns>Connection factory</returns>
        IDbConnectionFactory GetConnectionFactory();

    }
}
