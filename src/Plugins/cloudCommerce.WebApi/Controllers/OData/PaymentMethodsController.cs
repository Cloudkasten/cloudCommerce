using System.Web.Http;
using cloudCommerce.Core.Domain.Payments;
using cloudCommerce.Services.Payments;
using cloudCommerce.Web.Framework.WebApi;
using cloudCommerce.Web.Framework.WebApi.OData;
using cloudCommerce.Web.Framework.WebApi.Security;

namespace cloudCommerce.WebApi.Controllers.OData
{
	[WebApiAuthenticate(Permission = "ManagePaymentMethods")]
	public class PaymentMethodsController : WebApiEntityController<PaymentMethod, IPaymentService>
	{
		protected override void Insert(PaymentMethod entity)
		{
			Service.InsertPaymentMethod(entity);
		}
		protected override void Update(PaymentMethod entity)
		{
			Service.UpdatePaymentMethod(entity);
		}
		protected override void Delete(PaymentMethod entity)
		{
			Service.DeletePaymentMethod(entity);
		}

		[WebApiQueryable]
		public SingleResult<PaymentMethod> GetShippingMethod(int key)
		{
			return GetSingleResult(key);
		}

		// navigation properties

	}
}
