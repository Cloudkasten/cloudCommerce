using System.Data.Entity.ModelConfiguration;
using cloudCommerce.Core.Domain.Discounts;

namespace cloudCommerce.Data.Mapping.Discounts
{
    public partial class DiscountRequirementMap : EntityTypeConfiguration<DiscountRequirement>
    {
        public DiscountRequirementMap()
        {
            this.ToTable("DiscountRequirement");
            this.HasKey(dr => dr.Id);

            this.Property(dr => dr.SpentAmount).HasPrecision(18, 4);
        }
    }
}