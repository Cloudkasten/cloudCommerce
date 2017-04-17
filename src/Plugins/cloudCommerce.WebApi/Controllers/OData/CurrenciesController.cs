using System.Web.Http;
using cloudCommerce.Core.Domain.Directory;
using cloudCommerce.Services.Directory;
using cloudCommerce.Web.Framework.WebApi;
using cloudCommerce.Web.Framework.WebApi.OData;
using cloudCommerce.Web.Framework.WebApi.Security;

namespace cloudCommerce.WebApi.Controllers.OData
{
	[WebApiAuthenticate(Permission = "ManageCurrencies")]
	public class CurrenciesController : WebApiEntityController<Currency, ICurrencyService>
	{
		protected override void Insert(Currency entity)
		{
			Service.InsertCurrency(entity);
		}
		protected override void Update(Currency entity)
		{
			Service.UpdateCurrency(entity);
		}
		protected override void Delete(Currency entity)
		{
			Service.DeleteCurrency(entity);
		}

		[WebApiQueryable]
		public SingleResult<Currency> GetCurrency(int key)
		{
			return GetSingleResult(key);
		}
	}
}
