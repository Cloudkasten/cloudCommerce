using System.Collections.Generic;
using cloudCommerce.Web.Framework;
using cloudCommerce.Web.Framework.Modelling;

namespace cloudCommerce.Admin.Models.DataExchange
{
	public class ProfileInfoForProviderModel : ModelBase
	{
		public string SystemName { get; set; }

		[SmartResourceDisplayName("Admin.DataExchange.Export.ProfileForProvider")]
		public List<ProfileModel> Profiles { get; set; }
		
		public string ReturnUrl { get; set; }

		public class ProfileModel : EntityModelBase
		{
			public int? ScheduleTaskId { get; set; }

			public bool Enabled { get; set; }

			public string Name { get; set; }
		}
	}
}