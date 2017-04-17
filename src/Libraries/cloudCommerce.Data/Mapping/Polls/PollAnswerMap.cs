using System.Data.Entity.ModelConfiguration;
using cloudCommerce.Core.Domain.Polls;

namespace cloudCommerce.Data.Mapping.Polls
{
    public partial class PollAnswerMap : EntityTypeConfiguration<PollAnswer>
    {
        public PollAnswerMap()
        {
            this.ToTable("PollAnswer");
            this.HasKey(pa => pa.Id);
            this.Property(pa => pa.Name).IsRequired();

            this.HasRequired(pa => pa.Poll)
                .WithMany(p => p.PollAnswers)
                .HasForeignKey(pa => pa.PollId).WillCascadeOnDelete(true);
        }
    }
}