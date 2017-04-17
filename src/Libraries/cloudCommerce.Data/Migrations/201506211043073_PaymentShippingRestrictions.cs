namespace cloudCommerce.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
	using cloudCommerce.Data.Setup;

	public partial class PaymentShippingRestrictions : DbMigration, ILocaleResourcesProvider, IDataSeeder<SmartObjectContext>
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PaymentMethod",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PaymentMethodSystemName = c.String(nullable: false, maxLength: 4000),
                        ExcludedCustomerRoleIds = c.String(maxLength: 500),
                        ExcludedCountryIds = c.String(maxLength: 2000),
                        ExcludedShippingMethodIds = c.String(maxLength: 500),
                        CountryExclusionContextId = c.Int(nullable: false),
                        MinimumOrderAmount = c.Decimal(precision: 18, scale: 4),
                        MaximumOrderAmount = c.Decimal(precision: 18, scale: 4),
                        AmountRestrictionContextId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
				.Index(t => t.PaymentMethodSystemName);
            
            AddColumn("dbo.ShippingMethod", "ExcludedCustomerRoleIds", c => c.String(maxLength: 500));
            AddColumn("dbo.ShippingMethod", "CountryExclusionContextId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ShippingMethod", "CountryExclusionContextId");
            DropColumn("dbo.ShippingMethod", "ExcludedCustomerRoleIds");
            DropTable("dbo.PaymentMethod");
        }

		public bool RollbackOnFailure
		{
			get { return false; }
		}

		public void Seed(SmartObjectContext context)
		{
			context.MigrateLocaleResources(MigrateLocaleResources);

			context.MigrateSettings(x =>
			{
				x.Add("localizationsettings.loadalllocalizedpropertiesonstartup", true);
				x.Add("seosettings.loadallurlaliasesonstartup", true);
			});
		}

		public void MigrateLocaleResources(LocaleResourcesBuilder builder)
		{
			builder.AddOrUpdate("Admin.Common.Restrictions",
				"Restrictions",
				"Einschr�nkungen");

			builder.AddOrUpdate("Admin.Common.DeleteAll",
				"Delete all",
				"Alle l�schen");

			builder.AddOrUpdate("Admin.Common.RecordsDeleted",
				"{0} records were deleted.",
				"Es wurden {0} Datens�tze gel�scht.");

			builder.AddOrUpdate("Common.RequestProcessingFailed",
				"The request could not be processed.<br />Controller: {0}, Action: {1}, Reason: {2}.",
				"Die Anfrage konnte nicht ausgef�hrt werden.<br />Controller: {0}, Action: {1}, Grund: {2}.");

			builder.AddOrUpdate("Admin.System.Warnings.SitemapReachable.OK",
				"The sitemap for the store is reachable.",
				"Die Sitemap f�r den Shop ist erreichbar.");

			builder.AddOrUpdate("Admin.System.Warnings.SitemapReachable.Wrong",
				"The sitemap for the store is not reachable.",
				"Die Sitemap f�r den Shop ist nicht erreichbar.");


			builder.Delete("Admin.Configuration.Shipping.Restrictions.Updated");
			builder.Delete("Admin.Configuration.Shipping.Restrictions.Description");
			builder.Delete("Admin.Configuration.Shipping.Restrictions.Country");
			builder.Delete("Admin.Configuration.Shipping.Restrictions");
		}
    }
}
