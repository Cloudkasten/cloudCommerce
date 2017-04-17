using System;
using System.Collections.Generic;

namespace cloudCommerce.Core
{
	public interface ISoftDeletable
	{
		bool Deleted { get; }
	}
}
