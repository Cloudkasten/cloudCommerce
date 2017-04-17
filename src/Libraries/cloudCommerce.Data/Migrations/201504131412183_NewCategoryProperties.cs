namespace cloudCommerce.Data.Migrations
{
	using System;
	using System.Data.Entity.Migrations;
	using System.Web.Hosting;
	using cloudCommerce.Core.Data;
	using cloudCommerce.Data.Setup;

	public partial class NewCategoryProperties : DbMigration, ILocaleResourcesProvider, IDataSeeder<SmartObjectContext>
    {
        public override void Up()
        {
            AddColumn("dbo.Category", "FullName", c => c.String(maxLength: 400));
            AddColumn("dbo.Category", "BottomDescription", c => c.String());
            AddColumn("dbo.ReturnRequest", "RequestedActionUpdatedOnUtc", c => c.DateTime());
            AddColumn("dbo.ReturnRequest", "AdminComment", c => c.String(maxLength: 4000));
            AddColumn("dbo.CheckoutAttribute", "IsActive", c => c.Boolean(nullable: false));

			if (HostingEnvironment.IsHosted && DataSettings.Current.IsSqlServer)
			{
				this.SqlFileOrResource("LatestProductLoadAllPaged.sql");
			}
        }
        
        public override void Down()
        {
			// inverse of LatestProductLoadAllPaged.sql does not make sense to me

            DropColumn("dbo.CheckoutAttribute", "IsActive");
            DropColumn("dbo.ReturnRequest", "AdminComment");
            DropColumn("dbo.ReturnRequest", "RequestedActionUpdatedOnUtc");
            DropColumn("dbo.Category", "BottomDescription");
            DropColumn("dbo.Category", "FullName");
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
			builder.AddOrUpdate("Admin.Catalog.Categories.Fields.FullName",
				"Complete name",
				"Vollst�ndiger Name",
				"Complete name displayed as title on the category page.",
				"Vollst�ndiger Name, der als Titel auf der Warengruppenseite angezeigt wird.");

			builder.AddOrUpdate("Admin.Catalog.Categories.Fields.BottomDescription",
				"Bottom description",
				"Untere Beschreibung",
				"Optional second description displayed below products on the category page.",
				"Optionale zweite Beschreibung, die auf der Warengruppenseite unterhalb der Produkte angezeigt wird.");

			builder.AddOrUpdate("Admin.Catalog.Products.List.SearchWithoutCategories",
				"Without category mapping",
				"Ohne Warengruppenzuordnung",
				"Filters for products without category mapping.",
				"Filtert nach Produkten ohne Warengruppenzuordnung.");

			builder.AddOrUpdate("Admin.Catalog.Products.List.SearchWithoutManufacturers",
				"Without manufacturer mapping",
				"Ohne Herstellerzuordnung",
				"Filters for products without manufacturer mapping.",
				"Filtert nach Produkten ohne Herstellerzuordnung.");

			builder.AddOrUpdate("Admin.Common.AdminComment",
				"Admin comment",
				"Admin-Kommentar",
				"Admin comment for internal use. Won't be published.",
				"Kommentar f�r internen Gebrauch. Wird nicht ver�ffentlicht.");

			builder.AddOrUpdate("Admin.ReturnRequests.Fields.RequestedActionUpdatedOnUtc",
				"Last update of requested action",
				"Letzte Aktualisierung der angeforderten Aktion",
				"Date when the requested action was updated the last time.",
				"Datum, an dem die angeforderte Aktion zuletzt ge�ndert wurde.");

			builder.AddOrUpdate("Admin.Common.CreateMutuallyAssociations",
				"Create all mutual associations",
				"Alle gegenseitigen Zuordnungen erstellen");

			builder.AddOrUpdate("Admin.Common.AskCreateMutuallyAssociations",
				"Do you want to create all mutual associations?",
				"M�chten Sie alle gegenseitigen Zuordnungen erstellen?");

			builder.AddOrUpdate("Admin.Common.CreateMutuallyAssociationsResult",
				"There were {0} mutual association(s) created.",
				"Es wurden {0} gegenseitige Zuordnung(en) erstellt.");

			builder.AddOrUpdate("Admin.Configuration.Plugins.LicensingInvalidStoreUrl",
				"The license key cannot be activated for the entered store URL. Please enter the right store URL in your store details before activating the key.",
				"Der Lizenzschl�ssel kann f�r die hinterlegte Shop-URL nicht aktiviert werden. Bitte tragen Sie vor der Aktivierung in den Shop-Details die korrekte Shop-URL ein.");

			builder.AddOrUpdate("Admin.Configuration.Plugins.ConfirmLicensing",
				"Please check whether the licensing is done for the right store URL! Proceed with the licensing?",
				"Bitte �berpr�fen Sie, ob die Lizenzierung f�r die richtige Shop-URL erfolgt! Mit der Lizenzierung fortfahren?");

			builder.AddOrUpdate("Admin.Common.Unlicensed",
				"Unlicensed",
				"Unlizenziert");
		}
    }
}
