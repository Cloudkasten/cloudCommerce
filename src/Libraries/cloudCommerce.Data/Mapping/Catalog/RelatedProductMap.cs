using System.Data.Entity.ModelConfiguration;
using cloudCommerce.Core.Domain.Catalog;

namespace cloudCommerce.Data.Mapping.Catalog
{
    public partial class RelatedProductMap : EntityTypeConfiguration<RelatedProduct>
    {
        public RelatedProductMap()
        {
            this.ToTable("RelatedProduct");
            this.HasKey(c => c.Id);
        }
    }
}