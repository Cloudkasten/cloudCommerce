using System.Data.Entity.ModelConfiguration;
using cloudCommerce.Tax.Domain;

namespace cloudCommerce.Tax.Data
{
    public partial class TaxRateMap : EntityTypeConfiguration<TaxRate>
    {
        public TaxRateMap()
        {
            this.ToTable("TaxRate");
            this.HasKey(tr => tr.Id);
	        this.Property(tr => tr.Percentage).HasPrecision(18, 4);
        }
    }
}