using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using cloudCommerce.Core;
using cloudCommerce.Data;
using cloudCommerce.Data.Setup;
using cloudCommerce.GoogleMerchantCenter.Data.Migrations;

namespace cloudCommerce.GoogleMerchantCenter.Data
{

	public class GoogleProductObjectContext : ObjectContextBase
	{
        public const string ALIASKEY = "sm_object_context_google_product";

		static GoogleProductObjectContext()
		{
			var initializer = new MigrateDatabaseInitializer<GoogleProductObjectContext, Configuration>
			{
				TablesToCheck = new[] { "GoogleProduct" }
			};
			Database.SetInitializer(initializer);
		}

		/// <summary>
		/// For tooling support, e.g. EF Migrations
		/// </summary>
		public GoogleProductObjectContext()
			: base()
		{
		}

        public GoogleProductObjectContext(string nameOrConnectionString)
            : base(nameOrConnectionString, ALIASKEY) 
		{
		}


		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Configurations.Add(new GoogleProductRecordMap());
			base.OnModelCreating(modelBuilder);
		}

	}
}