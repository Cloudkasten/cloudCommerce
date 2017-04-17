using System.Collections.Generic;
using System.Runtime.Serialization;
using cloudCommerce.Core.Domain.Common;
using cloudCommerce.Core.Domain.Customers;
using cloudCommerce.Core.Domain.Orders;

namespace cloudCommerce.Core.Domain.Affiliates
{
    /// <summary>
    /// Represents an affiliate
    /// </summary>
    [DataContract]
	public partial class Affiliate : BaseEntity, ISoftDeletable
    {

        [DataMember]
        public int AddressId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the entity has been deleted
        /// </summary>
        [DataMember]
        public bool Deleted { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the entity is active
        /// </summary>
        [DataMember]
        public bool Active { get; set; }

        public virtual Address Address { get; set; }

    }
}
