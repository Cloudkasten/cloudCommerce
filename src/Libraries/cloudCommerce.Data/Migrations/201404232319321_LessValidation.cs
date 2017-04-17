namespace cloudCommerce.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
	using cloudCommerce.Data.Setup;

	public partial class LessValidation : DbMigration, ILocaleResourcesProvider, IDataSeeder<SmartObjectContext>
    {
        public override void Up()
        {
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
			builder.AddOrUpdate("Admin.Configuration.Themes.Notifications.ConfigureError",
				"LESS CSS Parser Error: Your changes were not saved because your configuration would lead to an error in the shop. For details see report.",
				"LESS CSS Parser Fehler: Ihre �nderungen wurden nicht gespeichert, da Ihre Konfiguration zu einem Fehler im Shop f�hren w�rde. Details siehe Fehlerbericht.");

			builder.AddOrUpdate("Admin.Configuration.Themes.Validation.ErrorReportTitle",
				"LESS parser error report",
				"LESS Parser Fehlerbericht");

			builder.AddOrUpdate("Admin.Configuration.Themes.Validation.RestorePrevValues",
				"Restore previous values",
				"Vorherige Werte widerherstellen");
		}
    }
}
