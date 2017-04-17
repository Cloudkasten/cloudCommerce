namespace cloudCommerce.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
	using cloudCommerce.Data.Setup;

	public partial class TaskUpdate : DbMigration, ILocaleResourcesProvider, IDataSeeder<SmartObjectContext>
    {
        public override void Up()
        {
            AddColumn("dbo.ScheduleTask", "LastError", c => c.String(maxLength: 1000));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ScheduleTask", "LastError");
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
			builder.AddOrUpdate("Admin.Catalog.Products.Variants.ProductVariantAttributes.AttributeCombinations.CombiNotExists",
				"The selected attribute combination does not exist yet.",
				"Die gew�hlte Attribut-Kombination existiert noch nicht.");

			builder.AddOrUpdate("Common.Duration",
				"Duration",
				"Dauer");
			builder.AddOrUpdate("Common.Never",
				"Never",
				"Nie");

			builder.AddOrUpdate("Admin.System.ScheduleTasks.StopOnError",
				"Stop on error",
				"Bei Fehler anhalten");

			builder.AddOrUpdate("Admin.System.ScheduleTasks.LastStart",
				"Last run",
				"Letzte Ausf�hrung");
			builder.AddOrUpdate("Admin.System.ScheduleTasks.LastEnd", // Obsolete
				"Last end",
				"Zuletzt beendet");
			builder.AddOrUpdate("Admin.System.ScheduleTasks.LastSuccess",
				"Last success",
				"Letzte erfolgreiche Ausf�hrung");

			builder.AddOrUpdate("Admin.System.ScheduleTasks.RunNow",
				"Run now",
				"Jetzt ausf�hren");

			builder.AddOrUpdate("Admin.System.ScheduleTasks.RunNow.Completed",
				"Task execution completed",
				"Ausf�hrung der Aufgabe abgeschlossen");

			builder.AddOrUpdate("Admin.System.ScheduleTasks.RunNow.IsRunning",
				"Is running...",
				"Wird ausgef�hrt...");

			builder.AddOrUpdate("Admin.System.ScheduleTasks.RunNow.Progress",
				"Task is now running in the background",
				"Aufgabe wird jetzt im Hintergrund ausgef�hrt");
		}
    }
}
