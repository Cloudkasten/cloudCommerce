using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using cloudCommerce.Core;
using cloudCommerce.Data;
using cloudCommerce.Data.Setup;
using cloudCommerce.Tax.Data.Migrations;

namespace cloudCommerce.Tax.Data
{
    /// <summary>
    /// Object context
    /// </summary>
    public class TaxRateObjectContext : ObjectContextBase
    {
        public const string ALIASKEY = "sm_object_context_tax_country_state_zip";

		static TaxRateObjectContext()
		{
			var initializer = new MigrateDatabaseInitializer<TaxRateObjectContext, Configuration>
			{
				TablesToCheck = new[] { "TaxRate" }
			};
			Database.SetInitializer(initializer);
		}

		/// <summary>
		/// For tooling support, e.g. EF Migrations
		/// </summary>
		public TaxRateObjectContext()
			: base()
		{
		}

        public TaxRateObjectContext(string nameOrConnectionString)
            : base(nameOrConnectionString, ALIASKEY)
        {
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new TaxRateMap());

            //disable EdmMetadata generation
            //modelBuilder.Conventions.Remove<IncludeMetadataConvention>();
            base.OnModelCreating(modelBuilder);
        }

    }
}