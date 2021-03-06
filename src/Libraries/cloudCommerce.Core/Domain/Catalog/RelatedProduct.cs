using System.Runtime.Serialization;
namespace cloudCommerce.Core.Domain.Catalog
{
    /// <summary>
    /// Represents a related product
    /// </summary>
	[DataContract]
	public partial class RelatedProduct : BaseEntity
    {
        /// <summary>
        /// Gets or sets the first product identifier
        /// </summary>
		[DataMember]
		public int ProductId1 { get; set; }

        /// <summary>
        /// Gets or sets the second product identifier
        /// </summary>
		[DataMember]
		public int ProductId2 { get; set; }

        /// <summary>
        /// Gets or sets the display order
        /// </summary>
		[DataMember]
		public int DisplayOrder { get; set; }
    }

}
