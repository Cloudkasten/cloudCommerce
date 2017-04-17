namespace cloudCommerce.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
	using cloudCommerce.Data.Setup;

	public partial class BetterReturnRequest : DbMigration, ILocaleResourcesProvider, IDataSeeder<SmartObjectContext>
    {
        public override void Up()
        {
			AddColumn("dbo.Order", "UpdatedOnUtc", c => c.DateTime(nullable: false, defaultValue: DateTime.UtcNow));
			AddColumn("dbo.Order", "RewardPointsRemaining", c => c.Int());
        }
        
        public override void Down()
        {
			DropColumn("dbo.Order", "UpdatedOnUtc");
			DropColumn("dbo.Order", "RewardPointsRemaining");
        }

		public bool RollbackOnFailure
		{
			get { return false; }
		}

		public void Seed(SmartObjectContext context)
		{
			context.MigrateLocaleResources(MigrateLocaleResources);

			context.Execute("Update [dbo].[Order] Set UpdatedOnUtc = CreatedOnUtc");
		}

		public void MigrateLocaleResources(LocaleResourcesBuilder builder)
		{
			builder.Delete("Admin.Orders.Products.ReturnRequests", "Admin.Orders.Fields.CancelOrderTotals", "Admin.Orders.Products.AddNew.Note2",
				"Admin.Catalog.Products.List.DownloadPDF");

			builder.AddOrUpdate("Admin.Orders.Products.ReturnRequest",
				"Return request",
				"R�cksendeauftrag");

			builder.AddOrUpdate("Admin.Orders.Products.ReturnRequest.Create",
				"Create return",
				"R�cksendung erstellen");

			builder.AddOrUpdate("Admin.ReturnRequests.Accept",
				"Accept",
				"Akzeptieren");

			builder.AddOrUpdate("Admin.ReturnRequests.Accept.Caption",
				"Accept return request",
				"R�cksendung akzeptieren");


			builder.AddOrUpdate("Admin.Orders.OrderItem.Update.Info",
				"Stock quantity old {0}, new {1}.<br />Reward points old {2}, new {3}.",
				"Lagerbestand alt {0}, neu {1}.<br />Bonuspunkte alt {2}, neu {3}.");

			builder.AddOrUpdate("Admin.Orders.OrderItem.AutoUpdate.AdjustInventory",
				"Adjust inventory",
				"Lagerbestand anpassen",
				"Determines whether to adjust the stock quantity proportionately.",
				"Legt fest, ob der Lagerbestand anteilig angepasst werden soll.");

			builder.AddOrUpdate("Admin.Orders.OrderItem.AutoUpdate.UpdateRewardPoints",
				"Reduce reward points",
				"Bonuspunkte abziehen",
				"Determines whether granted reward points should be deducted again proportionately.",
				"Legt fest, ob gew�hrte Bonuspunkte wieder anteilig abgezogen werden sollen.");

			builder.AddOrUpdate("Admin.Orders.OrderItem.AutoUpdate.UpdateTotals",
				"Update totals",
				"Summen anpassen",
				"Determines whether to update the order totals.",
				"Legt fest, ob die Auftragssummen angepasst werden sollen.");


			builder.AddOrUpdate("Admin.Common.ExportToPdf.All",
				"Export to PDF (all)",
				"Alles nach PDF exportieren");

			builder.AddOrUpdate("Admin.Common.ExportToPdf.Selected",
				"Export to PDF (selected)",
				"Nur Ausgew�hlte nach PDF exportieren");


			builder.AddOrUpdate("Admin.Catalog.Categories.Delete.Caption",
				"Delete category",
				"Warengruppe l�schen");

			builder.AddOrUpdate("Admin.Catalog.Categories.Delete.Hint",
				"How to treat child categories?",
				"Wie soll mit Unterwarengruppen verfahren werden?");

			builder.AddOrUpdate("Admin.Catalog.Categories.Delete.ResetParentOfChilds",
				"Remove the mapping to the parent category.",
				"Die Zuordnung zur �bergeordneten Warengruppe entfernen.");

			builder.AddOrUpdate("Admin.Catalog.Categories.Delete.DeleteChilds",
				"Delete as well.",
				"Ebenfalls l�schen.");


			builder.AddOrUpdate("Admin.Configuration.Settings.RewardPoints.PointsForProductReview",
				"Points for a product review",
				"Punkte f�r eine Produkt Rezension",
				"Specify number of points awarded for adding an approved product review.",
				"Bonuspunkte, die f�r das Verfassen einer genehmigten Produkt Rezension gew�hrt werden.");

			builder.AddOrUpdate("RewardPoints.Message.EarnedForProductReview",
				"Earned reward points for a product review at \"{0}\"",
				"Erhaltene Bonuspunkte f�r eine Produkt Rezension zu \"{0}\"");

			builder.AddOrUpdate("RewardPoints.Message.ReducedForProductReview",
				"Reduced reward points for a product review at \"{0}\"",
				"Abgezogene Bonuspunkte f�r eine Produkt Rezension zu \"{0}\"");
		}
    }
}
