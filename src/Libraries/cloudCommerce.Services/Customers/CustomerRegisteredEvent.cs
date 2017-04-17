using System.Collections.Generic;
using cloudCommerce.Core.Domain.Customers;

namespace cloudCommerce.Services.Customers
{
	/// <summary>
	/// An event message, which gets published after customer was registered
	/// </summary>
    public class CustomerRegisteredEvent
	{
        public Customer Customer
		{ 
			get; 
			set; 
		}
	}
}
