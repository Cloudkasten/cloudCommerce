namespace cloudCommerce.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
	using cloudCommerce.Data.Setup;

	public partial class AboutPage : DbMigration, ILocaleResourcesProvider, IDataSeeder<SmartObjectContext>
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
			builder.AddOrUpdate("Admin.Common.TaskSuccessfullyProcessed",
				"The task was successfully processed.",
				"Der Vorgang wurde erfolgreich ausgef�hrt.");

			builder.AddOrUpdate("Common.Description.Hint",
				"Description",
				"Beschreibung");

			builder.AddOrUpdate("Admin.Configuration.Settings.Catalog.HideBuyButtonInLists",
				"Hide buy-button in product lists",
				"Verberge Kaufen-Button in Produktlisten",
				"Check to hide the buy-button in product lists.",
				"Legt fest, ob der Kaufen-Button in Produktlisten ausgeblendet werden soll.");

			builder.AddOrUpdate("Admin.Common.About",
				"About",
				"�ber");

			builder.AddOrUpdate("Admin.Common.License",
				"License",
				"Lizenz");

			builder.AddOrUpdate("Admin.Help.NopCommerceNote",
				"cloudCommerce.NET is a derivation of the ASP.NET open source e-commerce solution {0}.",
				"cloudCommerce.NET ist ein Derivat der ASP.NET Open-Source E-Commerce-L�sung {0}.");

			builder.AddOrUpdate("Admin.Help.OtherWorkNote",
				"cloudCommerce.NET includes works distributed under the licenses listed below. Please refer to the specific resources for more detailed information about the authors, copyright notices and licenses.",
				"cloudCommerce.NET beinhaltet Werke, die unter den unten aufgef�hrten Lizenzen vertrieben werden. Bitte beachten Sie die betreffenden Ressourcen f�r ausf�hrlichere Informationen �ber Autoren, Copyright-Vermerke und Lizenzen.");
		}
	}
}
