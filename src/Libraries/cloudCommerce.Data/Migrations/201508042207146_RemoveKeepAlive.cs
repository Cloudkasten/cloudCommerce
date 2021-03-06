namespace cloudCommerce.Data.Migrations
{
	using System;
	using System.Data.Entity.Migrations;
	using System.Web.Hosting;
	using Core.Data;
	using cloudCommerce.Data.Setup;

	public partial class RemoveKeepAlive : DbMigration, ILocaleResourcesProvider, IDataSeeder<SmartObjectContext>
    {
        public override void Up()
        {
			if (HostingEnvironment.IsHosted && DataSettings.Current.IsSqlServer)
			{
				Sql("DELETE FROM [dbo].[ScheduleTask] WHERE [Type] = 'cloudCommerce.Services.Common.KeepAliveTask, cloudCommerce.Services'");
			}
        }
        
        public override void Down()
        {
        }

		public bool RollbackOnFailure
		{
			get { return false; }
		}

		public void Seed(SmartObjectContext context)
		{
			context.MigrateLocaleResources(MigrateLocaleResources);
		}

		public void MigrateLocaleResources(LocaleResourcesBuilder builder)
		{
			builder.AddOrUpdate("Admin.System.ScheduleTasks",
				"Scheduled Tasks",
				"Geplante Aufgaben");
		}
	}
}
