using System.Collections.Generic;
using System.Web.Mvc;
using cloudCommerce.Core.Domain.DataExchange;
using cloudCommerce.Web.Framework;
using cloudCommerce.Web.Framework.Modelling;

namespace cloudCommerce.Admin.Models.DataExchange
{
	public partial class ImportProfileListModel : EntityModelBase
	{
		[SmartResourceDisplayName("Admin.Common.Entity")]
		public ImportEntityType EntityType { get; set; }
		public List<SelectListItem> AvailableEntityTypes { get; set; }

		public List<ImportProfileModel> Profiles { get; set; }
	}
}