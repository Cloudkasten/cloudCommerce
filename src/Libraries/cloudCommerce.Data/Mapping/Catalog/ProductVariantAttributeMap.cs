using System.Data.Entity.ModelConfiguration;
using cloudCommerce.Core.Domain.Catalog;

namespace cloudCommerce.Data.Mapping.Catalog
{
    public partial class ProductVariantAttributeMap : EntityTypeConfiguration<ProductVariantAttribute>
    {
        public ProductVariantAttributeMap()
        {
			this.ToTable("Product_ProductAttribute_Mapping");
            this.HasKey(pva => pva.Id);
	        this.Ignore(pva => pva.AttributeControlType);

            this.HasRequired(pva => pva.Product)
                .WithMany(pva => pva.ProductVariantAttributes)
                .HasForeignKey(pva => pva.ProductId);
            
            this.HasRequired(pva => pva.ProductAttribute)
                .WithMany()
                .HasForeignKey(pva => pva.ProductAttributeId);
        }
    }
}