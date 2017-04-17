using System.Web.Http;
using cloudCommerce.Core.Domain.Directory;
using cloudCommerce.Services.Directory;
using cloudCommerce.Web.Framework.WebApi;
using cloudCommerce.Web.Framework.WebApi.OData;
using cloudCommerce.Web.Framework.WebApi.Security;

namespace cloudCommerce.WebApi.Controllers.OData
{
	[WebApiAuthenticate(Permission = "ManageDeliveryTimes")]
	public class DeliveryTimesController : WebApiEntityController<DeliveryTime, IDeliveryTimeService>
	{
		protected override void Insert(DeliveryTime entity)
		{
			Service.InsertDeliveryTime(entity);
		}
		protected override void Update(DeliveryTime entity)
		{
			Service.UpdateDeliveryTime(entity);
		}
		protected override void Delete(DeliveryTime entity)
		{
			Service.DeleteDeliveryTime(entity);
		}

		[WebApiQueryable]
		public SingleResult<DeliveryTime> GetDeliveryTime(int key)
		{
			return GetSingleResult(key);
		}
	}
}
