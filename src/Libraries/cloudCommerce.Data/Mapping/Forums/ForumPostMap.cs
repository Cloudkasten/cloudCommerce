using System.Data.Entity.ModelConfiguration;
using cloudCommerce.Core.Domain.Forums;

namespace cloudCommerce.Data.Mapping.Forums
{
    public partial class ForumPostMap : EntityTypeConfiguration<ForumPost>
    {
        public ForumPostMap()
        {
            this.ToTable("Forums_Post");
            this.HasKey(fp => fp.Id);
            this.Property(fp => fp.Text).IsRequired().IsMaxLength();
            this.Property(fp => fp.IPAddress).HasMaxLength(100);

            this.HasRequired(fp => fp.ForumTopic)
                .WithMany()
                .HasForeignKey(fp => fp.TopicId);

            this.HasRequired(fp => fp.Customer)
               .WithMany(c => c.ForumPosts)
               .HasForeignKey(fp => fp.CustomerId)
               .WillCascadeOnDelete(false);
        }
    }
}
