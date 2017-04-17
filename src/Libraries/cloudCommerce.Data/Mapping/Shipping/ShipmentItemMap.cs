using System.Data.Entity.ModelConfiguration;
using cloudCommerce.Core.Domain.Shipping;

namespace cloudCommerce.Data.Mapping.Shipping
{
    public partial class ShipmentItemMap : EntityTypeConfiguration<ShipmentItem>
    {
        public ShipmentItemMap()
        {
			this.ToTable("ShipmentItem");
            this.HasKey(si => si.Id);

            this.HasRequired(si => si.Shipment)
                .WithMany(s => s.ShipmentItems)
                .HasForeignKey(si => si.ShipmentId);
        }
    }
}