namespace cloudCommerce.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
	using cloudCommerce.Data.Setup;

	public partial class AttributeCombinationPrice : DbMigration, ILocaleResourcesProvider, IDataSeeder<SmartObjectContext>
    {
        public override void Up()
        {
            AddColumn("dbo.Product", "LowestAttributeCombinationPrice", c => c.Decimal(precision: 18, scale: 4));
            AddColumn("dbo.ProductVariantAttributeCombination", "Price", c => c.Decimal(precision: 18, scale: 4));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProductVariantAttributeCombination", "Price");
            DropColumn("dbo.Product", "LowestAttributeCombinationPrice");
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
			builder.AddOrUpdate("Admin.Catalog.Products.ProductVariantAttributes.AttributeCombinations.DeleteAllCombinations",
				"Delete all combinations",
				"Alle Kombinationen l�schen");

			builder.AddOrUpdate("Admin.Catalog.Products.ProductVariantAttributes.AttributeCombinations.AskToDeleteAll",
				"Would you like to delete all attribute combinations for this product?",
				"M�chten Sie s�mtliche Attribut-Kombinationen f�r dieses Produkt l�schen?");
		}
    }
}
