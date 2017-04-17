using System.Data.Entity.ModelConfiguration;
using cloudCommerce.Core.Domain.Stores;

namespace cloudCommerce.Data.Mapping.Stores
{
	public partial class StoreMappingMap : EntityTypeConfiguration<StoreMapping>
	{
		public StoreMappingMap()
		{
			this.ToTable("StoreMapping");
			this.HasKey(sm => sm.Id);

			this.Property(sm => sm.EntityName).IsRequired().HasMaxLength(400);
		}
	}
}