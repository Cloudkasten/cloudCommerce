using System.Data.Entity.ModelConfiguration;
using cloudCommerce.Core.Domain.Customers;

namespace cloudCommerce.Data.Mapping.Customers
{
    public partial class CustomerContentMap : EntityTypeConfiguration<CustomerContent>
    {
        public CustomerContentMap()
        {
            this.ToTable("CustomerContent");

            this.HasKey(cc => cc.Id);
            this.Property(cc => cc.IpAddress).HasMaxLength(200);

            this.HasRequired(cc => cc.Customer)
                .WithMany(c => c.CustomerContent)
                .HasForeignKey(cc => cc.CustomerId);

        }
    }
}