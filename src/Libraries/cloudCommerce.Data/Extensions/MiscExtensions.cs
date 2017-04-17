using System.Linq;

namespace cloudCommerce
{
	public static class MiscExtensions
	{
		public static bool IsEntityFrameworkProvider(this IQueryProvider provider)
		{
			return provider.GetType().FullName == "System.Data.Objects.ELinq.ObjectQueryProvider";
		}

	}
}
