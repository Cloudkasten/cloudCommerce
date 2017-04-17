namespace cloudCommerce.Data.Migrations
{
	using System.Data.Entity.Migrations;
	using cloudCommerce.Data.Setup;
	using cloudCommerce.Core.Domain.Media;
	using System.Linq;

	public partial class ThirdPartyEmailHandOver : DbMigration, ILocaleResourcesProvider, IDataSeeder<SmartObjectContext>
	{
        public override void Up()
        {
            AddColumn("dbo.Order", "AcceptThirdPartyEmailHandOver", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Order", "AcceptThirdPartyEmailHandOver");
        }

		public bool RollbackOnFailure
		{
			get { return false; }
		}

		public void Seed(SmartObjectContext context)
		{
			context.MigrateLocaleResources(MigrateLocaleResources);

			// Some users have disabled the "TransientMediaClearTask" due to a bug.
			// When the task is enabled again, it would delete media files, which are marked as transient
			// but are permanent actually. To avoid this, we have to set IsTransient to false.
			var transientPictures = context.Set<Picture>().Where(x => x.IsTransient == true).ToList();
			transientPictures.Each(x => x.IsTransient = false);

			var transientDownloads = context.Set<Download>().Where(x => x.IsTransient == true).ToList();
			transientDownloads.Each(x => x.IsTransient = false);

			context.SaveChanges();
		}

		public void MigrateLocaleResources(LocaleResourcesBuilder builder)
		{
			builder.AddOrUpdate("Admin.Common.Ignore", "Ignore", "Ignorieren");
			builder.AddOrUpdate("Common.My", "My", "Mein");

			builder.AddOrUpdate("Enums.cloudCommerce.Core.Domain.Orders.CheckoutThirdPartyEmailHandOver.None", "Do not show", "Nicht anzeigen");
			builder.AddOrUpdate("Enums.cloudCommerce.Core.Domain.Orders.CheckoutThirdPartyEmailHandOver.Deactivated", "Show deactivated", "Deaktiviert anzeigen");
			builder.AddOrUpdate("Enums.cloudCommerce.Core.Domain.Orders.CheckoutThirdPartyEmailHandOver.Activated", "Show activated", "Aktiviert anzeigen");

			builder.AddOrUpdate("Admin.Configuration.Settings.ShoppingCart.ThirdPartyEmailHandOver",
				"Consent for email transfer to third parties",
				"Zustimmung zur E-Mail Weitergabe an Dritte",
				"Specifies whether customers can agree to a transferring of their email address to third parties when ordering, and whether the checkbox is enabled by default during checkout.",
				"Legt fest, ob Kunden bei einer Bestellung der Weitergabe ihrer E-Mail Adresse an Dritte zustimmen k�nnen und ob die Checkbox daf�r standardm��ig aktiviert ist.");

			builder.AddOrUpdate("Admin.Configuration.Settings.ShoppingCart.ThirdPartyEmailHandOverLabel",
				"Text for email transfer consent",
				"Text f�r E-Mail Weitergabe",
				"Specifies the text to be displayed to the customer. Please choose a specific reason, e.g. 'I agree to the transfer and storage of my email address for TrustedShops buyer protection.'",
				"Legt den Text f�r die Zustimmung zur Weitergabe der E-Mail Adresse an Dritte fest. W�hlen Sie bitte einen konkreten Grund f�r die Weitergabe, z.B. 'Mit der �bermittlung und Speicherung meiner E-Mail-Adresse zur Abwicklung des K�uferschutzes durch Trusted Shops bin ich einverstanden.'");

			builder.AddOrUpdate("Admin.Configuration.Settings.ShoppingCart.ThirdPartyEmailHandOverLabel.Default",
				"I agree to the transfer and storage of my email address by third parties.",
				"Mit der �bermittlung und Speicherung meiner E-Mail-Adresse durch dritte Parteien bin ich einverstanden.");

			builder.AddOrUpdate("Admin.Orders.Fields.AcceptThirdPartyEmailHandOver",
				"Accepts transfer of email",
				"Akzeptiert Weitergabe der E-Mail",
				"Indicates whether the customer has agreed to a transfer of his email address to third parties.",
				"Gibt an, ob der Kunde bei der Bestellung einer Weitergabe seiner E-Mail Adresse an Dritte zugestimmt hat oder nicht.");

			builder.AddOrUpdate("Admin.OrderNotice.OrderCaptureError",
				"Unable to capture payment for order {0}.",
				"Es ist ein Fehler bei der Zahlungsbuchung zu Auftrag {0} aufgetreten.");

			builder.AddOrUpdate("Enums.cloudCommerce.Core.Domain.DataExchange.ExportDescriptionMerging.None",
				"None", "Keine");

			builder.AddOrUpdate("Admin.Configuration.Settings.Catalog.ShowManufacturerPicturesInProductDetail",
				"Show manufacturer pictures",
				"Bilder von Herstellern anzeigen",
				"Specifies whether to show manufacturer pictures on product detail page.",
				"Legt fest, ob Herstellerbilder auf der Produktdetailseite angezeigt werden sollen.");

			builder.AddOrUpdate("Admin.Configuration.Settings.Catalog.HideManufacturerDefaultPictures",
				"Hide default picture for manufacturers",
				"Standardbild bei Herstellern ausblenden",
				"Specifies whether to hide the default image for manufacturers. The default image is shown when no image is assigned to a manufacturer.",
				"Legt fest, ob das Standardbild bei Herstellern ausgeblendet werden soll. Das Standardbild wird angezeigt, wenn dem Hersteller kein Bild zugeordnet ist.");

			builder.AddOrUpdate("Admin.DataExchange.Export.Partition.Note",
				"With the following settings you can partition the data to be exported. This includes<ul><li>Skipping the first n records</li><li>The maximum number of records to be exported</li><li>The number of records per export file</li><li>Export data for each shop in a separate file</li></ul>By default, all data of a store will be exported into one file.",
				"Mit den folgenden Einstellungen lassen sich die zu exportierenden Daten aufteilen. Dazu z�hlt<ul><li>Das �berspringen der ersten n Datens�tze</li><li>Die maximale Anzahl zu exportierender Datens�tze</li><li>Die Anzahl der Datens�tze pro Exportdatei</li><li>Daten von jedem Shop in eine separate Datei exportieren</li></ul>Standardm��ig werden alle Daten eines Shops in eine Datei exportiert.");

			builder.AddOrUpdate("Admin.DataExchange.Export.Partition.Validate",
				"Partitioning setting values must be greater than or equal to 0.",
				"Einstellungen zur Aufteilung m�ssen gr��er oder gleich 0 sein.");

			builder.AddOrUpdate("Admin.DataExchange.Export.Filter.IsActiveSubscriber",
				"Only active subscribers",
				"Nur aktive Abonnenten",
				"Filter by active or inactive newsletter subscribers.",
				"Nach aktiven bzw. inaktiven Newsletter Abonnenten filtern.");

			builder.AddOrUpdate("Admin.DataExchange.Export.Filter.IsActiveCustomer",
				"Only active customers",
				"Nur aktive Kunden",
				"Filter by active or inactive customers.",
				"Nach aktiven bzw. inaktiven Kunden filtern.");

			builder.AddOrUpdate("Admin.DataExchange.Export.Filter.IsTaxExempt",
				"Only tax exempt customers",
				"Nur MwSt. befreite Kunden",
				"Filter by tax exempt customers.",
				"Nach MwSt. befreiten Kunden filtern.");

			builder.AddOrUpdate("Admin.DataExchange.Export.Filter.BillingCountryIds",
				"Billing countries",
				"Rechnungsl�nder",
				"Filter by billing countries.",
				"Nach Rechnungsl�ndern filtern.");

			builder.AddOrUpdate("Admin.DataExchange.Export.Filter.ShippingCountryIds",
				"Shipping countries",
				"Versandl�nder",
				"Filter by shipping countries.",
				"Nach Versandl�ndern filtern.");

			builder.AddOrUpdate("Admin.DataExchange.Export.Filter.LastActivityFrom",
				"Last activity from",
				"Zuletzt aktiv von",
				"Filter by date of last store activity.",
				"Nach dem Datum der letzten Shop Aktivit�t filtern.");

			builder.AddOrUpdate("Admin.DataExchange.Export.Filter.LastActivityTo",
				"Last active until",
				"Zuletzt aktiv bis",
				"Filter by date of last store activity.",
				"Nach dem Datum der letzten Shop-Aktivit�t filtern.");

			builder.AddOrUpdate("Admin.DataExchange.Export.Filter.HasSpentAtLeastAmount",
				"Has spent amount x",
				"Hat Betrag x ausgegeben",
				"Filter by spent amount.",
				"Nach dem insgesamt ausgegebenen Betrag filtern.");

			builder.AddOrUpdate("Admin.DataExchange.Export.Filter.HasPlacedAtLeastOrders",
				"Has placed x orders",
				"Hat x Bestellungen",
				"Filter by number of placed orders.",
				"Nach der Anzahl der get�tigten Bestellungen filtern.");

			builder.AddOrUpdate("Admin.DataExchange.Export.SystemProfileNote",
				"The following list contains system profiles, which are provided by plugins such as the <a href='http://community.smartstore.com/index.php?/files/file/85-smartstorenet-common-export-providers/' target='_blank'>Data Export Plugin</a>. You can customize system profiles as desired, but cannot create new ones. These profiles also add additional action buttons. You will find these above data lists, such as the product or order list.",
				"Die folgende Liste enth�lt Systemprofile, die von Plugins wie bspw. dem <a href='http://community.smartstore.com/index.php?/files/file/85-smartstorenet-common-export-providers/' target='_blank'>Datenexporte Plugin</a> bereitgestellt werden. Sie k�nnen Systemprofile nach Belieben anpassen, aber keine Neuen erstellen. F�r diese Profile stehen au�erdem zus�tzliche Aktions-Buttons zur Verf�gung. Sie finden diese �ber den entsprechenden Listen, wie z.B. der Produkt- oder Auftragsliste.");

			builder.AddOrUpdate("Admin.DataExchange.AddNewProfile",
				"New profile",
				"Neues Profil");

			builder.AddOrUpdate("Admin.DataExchange.Import.ProfileCreationNote",
				"Please select the import object and upload an import file.",
				"W�hlen Sie bitte das zu importierende Objekt und laden Sie eine Importdatei hoch.");

			builder.Delete("Admin.DataExchange.Import.ProfileEntitySelectNote");

			builder.AddOrUpdate("Admin.Configuration.Restriction.SaveBeforeEdit",
				"You need to save before you can specify restrictions.",
				"Sie m�ssen zun�chst speichern, bevor Sie Einschr�nkungen festlegen k�nnen.");

			builder.AddOrUpdate("Admin.Configuration.Settings.CustomerUser.CustomerNumberMethod",
				"Customer numbers",
				"Kundennummern",
				"Specifies whether to assign customer numbers and whether they should be created automatically.",
				"Legt fest, ob Kundennummern vergeben werden und ob diese automatisch vergeben werden sollen.");

			builder.AddOrUpdate("Admin.Configuration.Settings.CustomerUser.CustomerNumberVisibility",
				"Customer number presentation",
				"Darstellung der Kundennummer",
				"Specifies the presentation and handling of the customer number to the customer.",
				"Legt die Darstellung und Handhabung der Kundennummer gegen�ber dem Kunden fest.");

			builder.AddOrUpdate("Enums.cloudCommerce.Core.Domain.Customers.CustomerNumberMethod.Disabled", "Disabled", "Deaktiviert");
			builder.AddOrUpdate("Enums.cloudCommerce.Core.Domain.Customers.CustomerNumberMethod.Enabled", "Enabled", "Aktiviert");
			builder.AddOrUpdate("Enums.cloudCommerce.Core.Domain.Customers.CustomerNumberMethod.AutomaticallySet", "Automatically assigned", "Automatisch vergeben");

			builder.AddOrUpdate("Enums.cloudCommerce.Core.Domain.Customers.CustomerNumberVisibility.None",	"Do not display", "Nicht anzeigen");
			builder.AddOrUpdate("Enums.cloudCommerce.Core.Domain.Customers.CustomerNumberVisibility.Display", "Display", "Anzeigen");
			builder.AddOrUpdate("Enums.cloudCommerce.Core.Domain.Customers.CustomerNumberVisibility.EditableIfEmpty", "Editable if empty", "Editierbar falls leer");
			builder.AddOrUpdate("Enums.cloudCommerce.Core.Domain.Customers.CustomerNumberVisibility.Editable", "Always editable", "Immer editierbar");

			builder.AddOrUpdate("Admin.Common.FileInUse",
				"The file is in use and cannot be opened.",
				"Die Datei ist in Benutzung und kann daher nicht ge�ffnet werden.");


			builder.AddOrUpdate("Admin.DataExchange.Export.UserProfilesTitle",
				"User profiles",
				"Benutzerprofile");
			builder.AddOrUpdate("Admin.DataExchange.Export.SystemProfilesTitle",
				"System profiles",
				"Systemprofile");

			builder.AddOrUpdate("Admin.DataExchange.Export.CompletedEmailAddresses",
				"Email addresses to",
				"E-Mail Adressen an",
				"Specifies the email addresses where to send the notification message.",
				"Legt die E-Mail Adressen fest, an die die Benachrichtigung geschickt werden soll.");

			builder.AddOrUpdate("Admin.DataExchange.Export.Deployment.EmailAddresses",
				"Email addresses to",
				"E-Mail Adressen an",
				"Specifies the email addresses where to send the data.",
				"Legt die E-Mail Adressen fest, an die die Daten verschickt werden soll.");

			builder.AddOrUpdate("Admin.Common.FileNotFound", "File not found", "Datei nicht gefunden");

			builder.AddOrUpdate("Admin.Common.EnterEmailAdress",
				"Please enter an email address.",
				"Bitte geben Sie eine E-Mail-Adresse ein.");

			builder.AddOrUpdate("Admin.Configuration.EmailAccounts.TestingEmail",
				"Testing email functionality.",
				"Test der E-Mail-Funktion.");

			builder.AddOrUpdate("Admin.Common.EmailSuccessfullySent",
				"The email has been successfully sent.",
				"Die E-Mail wurde erfolgreich versendet.");

			builder.AddOrUpdate("Admin.Common.SkipAndTakeGreaterThanOrEqualZero",
				"Values for skip and limit must be greater than or equal to 0.",
				"Werte f�r �berspringen und Begrenzen m�ssen gr��er oder gleich 0 sein.");
		}
	}
}
