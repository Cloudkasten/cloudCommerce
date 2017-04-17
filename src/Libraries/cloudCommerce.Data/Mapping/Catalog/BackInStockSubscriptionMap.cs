using System.Data.Entity.ModelConfiguration;
using cloudCommerce.Core.Domain.Catalog;

namespace cloudCommerce.Data.Mapping.Catalog
{
    public partial class BackInStockSubscriptionMap : EntityTypeConfiguration<BackInStockSubscription>
    {
        public BackInStockSubscriptionMap()
        {
            this.ToTable("BackInStockSubscription");
            this.HasKey(x => x.Id);
            
            this.HasRequired(x => x.Product)
                .WithMany()
                .HasForeignKey(x => x.ProductId)
                .WillCascadeOnDelete(true);
            
            this.HasRequired(x => x.Customer)
                .WithMany()
                .HasForeignKey(x => x.CustomerId)
                .WillCascadeOnDelete(true);
        }
    }
}