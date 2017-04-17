using System.Data.Entity.ModelConfiguration;
using cloudCommerce.Core.Domain.Payments;

namespace cloudCommerce.Data.Mapping.Payments
{
	public partial class PaymentMethodMap : EntityTypeConfiguration<PaymentMethod>
	{
		public PaymentMethodMap()
		{
			this.ToTable("PaymentMethod");
			this.HasKey(x => x.Id);

			this.Property(x => x.PaymentMethodSystemName).IsRequired().HasMaxLength(4000);

			this.Property(x => x.FullDescription).HasMaxLength(4000);
		}
	}
}
