using cloudCommerce.Core.Domain.Media;

namespace cloudCommerce.Core.Domain.Messages
{
	public enum EmailAttachmentStorageLocation
	{
		/// <summary>
		/// Attachment is embedded as Blob
		/// </summary>
		Blob,

		/// <summary>
		/// Attachment is a reference to <see cref="Download"/>
		/// </summary>
		FileReference,
		
		/// <summary>
		/// Attachment is located on disk (physical or virtual path)
		/// </summary>
		Path
	}
}
