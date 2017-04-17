using System.Collections.Generic;

namespace cloudCommerce.Core
{
	public interface IMergedData
	{
		bool MergedDataIgnore { get; set; }
		Dictionary<string, object> MergedDataValues { get; }
	}
}
