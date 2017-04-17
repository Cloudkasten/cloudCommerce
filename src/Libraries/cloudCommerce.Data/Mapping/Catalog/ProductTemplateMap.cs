using System.Data.Entity.ModelConfiguration;
using cloudCommerce.Core.Domain.Catalog;

namespace cloudCommerce.Data.Mapping.Catalog
{
    public partial class ProductTemplateMap : EntityTypeConfiguration<ProductTemplate>
    {
        public ProductTemplateMap()
        {
            this.ToTable("ProductTemplate");
            this.HasKey(p => p.Id);
            this.Property(p => p.Name).IsRequired().HasMaxLength(400);
            this.Property(p => p.ViewPath).IsRequired().HasMaxLength(400);
        }
    }
}