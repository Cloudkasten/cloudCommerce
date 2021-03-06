using System.Data.Entity.ModelConfiguration;
using cloudCommerce.ShippingByWeight.Domain;

namespace cloudCommerce.ShippingByWeight.Data
{
    public partial class ShippingByWeightRecordMap : EntityTypeConfiguration<ShippingByWeightRecord>
    {
        public ShippingByWeightRecordMap()
        {
            this.ToTable("ShippingByWeight");
            this.HasKey(x => x.Id);
            this.Property(x => x.Zip).IsOptional();
        }
    }
}