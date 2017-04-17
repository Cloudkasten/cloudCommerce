using System.Web.Http;
using cloudCommerce.Core.Domain.Shipping;
using cloudCommerce.Services.Shipping;
using cloudCommerce.Web.Framework.WebApi;
using cloudCommerce.Web.Framework.WebApi.OData;
using cloudCommerce.Web.Framework.WebApi.Security;

namespace cloudCommerce.WebApi.Controllers.OData
{
	[WebApiAuthenticate(Permission = "ManageOrders")]
	public class ShipmentsController : WebApiEntityController<Shipment, IShipmentService>
	{
		protected override void Insert(Shipment entity)
		{
			Service.InsertShipment(entity);
		}
		protected override void Update(Shipment entity)
		{
			Service.UpdateShipment(entity);
		}
		protected override void Delete(Shipment entity)
		{
			Service.DeleteShipment(entity);
		}

		[WebApiQueryable]
		public SingleResult<Shipment> GetShipment(int key)
		{
			return GetSingleResult(key);
		}
	}
}
