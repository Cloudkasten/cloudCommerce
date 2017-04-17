using System;
using cloudCommerce.Core.Localization;

namespace cloudCommerce.Web.Framework.Localization
{
	public interface IText
	{
		LocalizedString Get(string key, params object[] args);
	}
}
