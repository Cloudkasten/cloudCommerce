using System.Data.Entity.ModelConfiguration;
using cloudCommerce.Core.Domain.News;

namespace cloudCommerce.Data.Mapping.News
{
    public partial class NewsCommentMap : EntityTypeConfiguration<NewsComment>
    {
        public NewsCommentMap()
        {
            this.ToTable("NewsComment");
            //commented because it's already configured by CustomerContentMap class
            //this.HasKey(pr => pr.Id);
			this.Property(nc => nc.CommentText).IsMaxLength();
            this.HasRequired(nc => nc.NewsItem)
                .WithMany(n => n.NewsComments)
                .HasForeignKey(nc => nc.NewsItemId);
        }
    }
}