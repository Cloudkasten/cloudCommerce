using System.Web.Http;
using cloudCommerce.Core.Domain.Localization;
using cloudCommerce.Services.Localization;
using cloudCommerce.Web.Framework.WebApi;
using cloudCommerce.Web.Framework.WebApi.OData;
using cloudCommerce.Web.Framework.WebApi.Security;

namespace cloudCommerce.WebApi.Controllers.OData
{
	[WebApiAuthenticate(Permission = "ManageLanguages")]
	public class LocalizedPropertysController : WebApiEntityController<LocalizedProperty, ILocalizedEntityService>
	{
		protected override void Insert(LocalizedProperty entity)
		{
			Service.InsertLocalizedProperty(entity);
		}
		protected override void Update(LocalizedProperty entity)
		{
			Service.UpdateLocalizedProperty(entity);
		}
		protected override void Delete(LocalizedProperty entity)
		{
			Service.DeleteLocalizedProperty(entity);
		}

		[WebApiQueryable]
		public SingleResult<LocalizedProperty> GetLocalizedProperty(int key)
		{
			return GetSingleResult(key);
		}

		// navigation properties

		[WebApiQueryable]
		public SingleResult<Language> GetLanguage(int key)
		{
			return GetRelatedEntity(key, x => x.Language);
		}
	}
}
