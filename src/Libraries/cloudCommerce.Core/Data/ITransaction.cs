using System;

namespace cloudCommerce.Core.Data
{
	public interface ITransaction : IDisposable
	{
		void Commit();
		void Rollback();
	}
}
