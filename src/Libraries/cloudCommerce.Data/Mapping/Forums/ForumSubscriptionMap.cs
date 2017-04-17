using System.Data.Entity.ModelConfiguration;
using cloudCommerce.Core.Domain.Forums;

namespace cloudCommerce.Data.Mapping.Forums
{
    public partial class ForumSubscriptionMap : EntityTypeConfiguration<ForumSubscription>
    {
        public ForumSubscriptionMap()
        {
            this.ToTable("Forums_Subscription");
            this.HasKey(fs => fs.Id);

            this.HasRequired(fs => fs.Customer)
                .WithMany()
                .HasForeignKey(fs => fs.CustomerId)
                .WillCascadeOnDelete(false);
        }
    }
}
