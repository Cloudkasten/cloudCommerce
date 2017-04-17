using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using cloudCommerce.Core.Domain.Tasks;

namespace cloudCommerce.Core.Events
{
	/// <summary>
	/// to initialize scheduled tasks in Application_Start
	/// </summary>
	public class AppInitScheduledTasksEvent
	{
		public IList<ScheduleTask> ScheduledTasks { get; set; }
	}
}
