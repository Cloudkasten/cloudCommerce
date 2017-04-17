using System.Data.Entity.ModelConfiguration;
using cloudCommerce.Core.Domain.Catalog;

namespace cloudCommerce.Data.Mapping.Catalog
{
    public partial class ProductReviewMap : EntityTypeConfiguration<ProductReview>
    {
        public ProductReviewMap()
        {
            this.ToTable("ProductReview");
            //commented because it's already configured by CustomerContentMap class
            //this.HasKey(pr => pr.Id);
			this.Property(m => m.ReviewText).IsMaxLength();
            this.HasRequired(pr => pr.Product)
                .WithMany(p => p.ProductReviews)
                .HasForeignKey(pr => pr.ProductId);
        }
    }
}