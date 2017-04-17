using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Infrastructure.DependencyResolution;
using System.Linq;
using cloudCommerce.Core.Data;
using cloudCommerce.Data.Setup;

namespace cloudCommerce.Data.Tests
{

	public class TestDbConfiguration : DbConfiguration
	{
		public TestDbConfiguration()
		{
			base.SetDefaultConnectionFactory(new SqlCeConnectionFactory("System.Data.SqlServerCe.4.0"));
		}
	}

}
