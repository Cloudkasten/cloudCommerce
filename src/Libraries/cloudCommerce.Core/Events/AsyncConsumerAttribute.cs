using System;

namespace cloudCommerce.Core.Events
{
	[AttributeUsage(AttributeTargets.Class, Inherited=true, AllowMultiple=false)]
	public class AsyncConsumerAttribute : Attribute
	{
	}
}
