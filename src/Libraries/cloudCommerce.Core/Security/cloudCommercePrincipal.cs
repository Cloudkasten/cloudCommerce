using System.Security;
using System.Security.Claims;
using System.Security.Principal;
using System.Web.Security;
using cloudCommerce.Core.Domain.Customers;

namespace cloudCommerce.Core
{

	public class cloudCommerceIdentity : ClaimsIdentity
	{
		[SecuritySafeCritical]
		public cloudCommerceIdentity(int customerId, string name, string type) 
			: base(new GenericIdentity(name, type))
		{
			CustomerId = customerId;
		}

		public int CustomerId { get; private set; }

		public override bool IsAuthenticated { get { return CustomerId != 0; } }
	}


	public class cloudCommercePrincipal : IPrincipal
	{
		public cloudCommercePrincipal(Customer customer, string type)
		{
			this.Identity = new cloudCommerceIdentity(customer.Id, customer.Username, type);
		}

		public bool IsInRole(string role)
		{
			return (Identity != null && Identity.IsAuthenticated && role.HasValue() && Roles.IsUserInRole(Identity.Name, role));
		}

		public IIdentity Identity { get; private set; }
	}
}
