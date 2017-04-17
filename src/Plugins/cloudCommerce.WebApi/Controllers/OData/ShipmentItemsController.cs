using System.Web.Http;
using cloudCommerce.Core.Domain.Shipping;
using cloudCommerce.Services.Shipping;
using cloudCommerce.Web.Framework.WebApi;
using cloudCommerce.Web.Framework.WebApi.OData;
using cloudCommerce.Web.Framework.WebApi.Security;

namespace cloudCommerce.WebApi.Controllers.OData
{
	[WebApiAuthenticate(Permission = "ManageOrders")]
	public class ShipmentItemsController : WebApiEntityController<ShipmentItem, IShipmentService>
	{
		protected override void Insert(ShipmentItem entity)
		{
			Service.InsertShipmentItem(entity);
		}
		protected override void Update(ShipmentItem entity)
		{
			Service.UpdateShipmentItem(entity);
		}
		protected override void Delete(ShipmentItem entity)
		{
			Service.DeleteShipmentItem(entity);
		}

		[WebApiQueryable]
		public SingleResult<ShipmentItem> GetShipmentItem(int key)
		{
			return GetSingleResult(key);
		}
	}
}
