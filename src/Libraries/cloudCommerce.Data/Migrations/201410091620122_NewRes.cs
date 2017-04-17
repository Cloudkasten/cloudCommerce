namespace cloudCommerce.Data.Migrations
{
	using System;
	using System.Linq;
	using System.Data.Entity.Migrations;
	using cloudCommerce.Core.Domain.Tasks;
	using cloudCommerce.Data.Setup;
	using cloudCommerce.Core.Domain.Localization;

	public partial class NewRes : DbMigration, ILocaleResourcesProvider, IDataSeeder<SmartObjectContext>
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

			// update scheduled task types
			var table = context.Set<ScheduleTask>();

			ScheduleTask task;

			task = table.FirstOrDefault(x => x.Name.StartsWith("PromotionFeed.Froogle"));
			if (task != null)
			{
				task.Name = "cloudCommerce.GoogleMerchantCenter feed file generation";
				task.Type = "cloudCommerce.GoogleMerchantCenter.StaticFileGenerationTask, cloudCommerce.GoogleMerchantCenter";
			}

			task = table.FirstOrDefault(x => x.Name.StartsWith("PromotionFeed.Billiger"));
			if (task != null)
			{
				task.Name = "cloudCommerce.Billiger feed file generation";
				task.Type = "cloudCommerce.Billiger.StaticFileGenerationTask, cloudCommerce.Billiger";
			}

			task = table.FirstOrDefault(x => x.Name.StartsWith("PromotionFeed.Guenstiger"));
			if (task != null)
			{
				task.Name = "cloudCommerce.Guenstiger feed file generation";
				task.Type = "cloudCommerce.Guenstiger.StaticFileGenerationTask, cloudCommerce.Guenstiger";
			}

			task = table.FirstOrDefault(x => x.Name.StartsWith("PromotionFeed.ElmarShopinfo"));
			if (task != null)
			{
				task.Name = "cloudCommerce.ElmarShopinfo feed file generation";
				task.Type = "cloudCommerce.ElmarShopinfo.StaticFileGenerationTask, cloudCommerce.ElmarShopinfo";
			}

			task = table.FirstOrDefault(x => x.Name.StartsWith("PromotionFeed.Shopwahl"));
			if (task != null)
			{
				task.Name = "cloudCommerce.Shopwahl feed file generation";
				task.Type = "cloudCommerce.Shopwahl.StaticFileGenerationTask, cloudCommerce.Shopwahl";
			}

			task = table.FirstOrDefault(x => x.Name.StartsWith("MailChimp"));
			if (task != null)
			{
				task.Type = "cloudCommerce.MailChimp.MailChimpSynchronizationTask, cloudCommerce.MailChimp";
			}

			context.SaveChanges();
		}

		public void MigrateLocaleResources(LocaleResourcesBuilder builder)
		{
			builder.AddOrUpdate("Admin.Promotions").Value("de", "Marketing");
			builder.AddOrUpdate("Admin.Plugins.Manage",
				"Manage plugins",
				"Plugins verwalten");

			builder.AddOrUpdate("admin.help.nopcommercenote",
				"cloudCommerce.NET is a fork of the ASP.NET open source e-commerce solution {0}.",
				"cloudCommerce.NET ist ein Fork der ASP.NET Open-Source E-Commerce-L�sung {0}.");

			builder.AddOrUpdate("Payment.ExpirationDate",
				"Valid until",
				"G�ltig bis");

			builder.Update("Plugins.Payment.CashOnDelivery.PaymentInfoDescription")
				.Value("en", "Once your order is placed, you will be contacted by our staff to confirm the order.")
				.Value("de", "Sobald Ihre Bestellung abgeschlo�en ist, werden Sie pers�nlich von einem unserer Mitarbeiter kontaktiert, um die Bestellung zu best�tigen.");

			builder.Update("Plugins.Payment.Invoice.PaymentInfoDescription")
				.Value("en", "Once your order is placed, you will be contacted by our staff to confirm the order.")
				.Value("de", "Sobald Ihre Bestellung abgeschlo�en ist, werden Sie pers�nlich von einem unserer Mitarbeiter kontaktiert, um die Bestellung zu best�tigen.");

			builder.Update("Plugins.Payment.DirectDebit.PaymentInfoDescription")
				.Value("en", "Once your order is placed, you will be contacted by our staff to confirm the order.")
				.Value("de", "Sobald Ihre Bestellung abgeschlo�en ist, werden Sie pers�nlich von einem unserer Mitarbeiter kontaktiert, um die Bestellung zu best�tigen.");

			builder.Update("Plugins.Payment.PayInStore.PaymentInfoDescription")
				.Value("en", "Reserve items at your local store, and pay in store when you pick up your order.")
				.Value("de", "Reservieren Sie Produkte und zahlen Sie an der Kasse in unserem Ladenlokal.");

			builder.Update("Plugins.Payment.Prepayment.PaymentInfoDescription")
				.Value("en", "Once your order is placed, you will be contacted by our staff to confirm the order.")
				.Value("de", "Sobald Ihre Bestellung abgeschlo�en ist, werden Sie pers�nlich von einem unserer Mitarbeiter kontaktiert, um die Bestellung zu best�tigen.");

		}
	}
}
