using System.Web.Http;
using cloudCommerce.Core.Domain.Localization;
using cloudCommerce.Services.Localization;
using cloudCommerce.Web.Framework.WebApi;
using cloudCommerce.Web.Framework.WebApi.OData;
using cloudCommerce.Web.Framework.WebApi.Security;

namespace cloudCommerce.WebApi.Controllers.OData
{
	[WebApiAuthenticate(Permission = "ManageLanguages")]
	public class LanguagesController : WebApiEntityController<Language, ILanguageService>
	{
		protected override void Insert(Language entity)
		{
			Service.InsertLanguage(entity);
		}
		protected override void Update(Language entity)
		{
			Service.UpdateLanguage(entity);
		}
		protected override void Delete(Language entity)
		{
			Service.DeleteLanguage(entity);
		}

		[WebApiQueryable]
		public SingleResult<Language> GetLanguage(int key)
		{
			return GetSingleResult(key);
		}
	}
}
