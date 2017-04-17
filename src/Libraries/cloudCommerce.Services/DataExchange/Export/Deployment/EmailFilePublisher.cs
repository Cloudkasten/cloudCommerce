using System;
using System.IO;
using System.Linq;
using cloudCommerce.Core.Domain;
using cloudCommerce.Core.Domain.Messages;
using cloudCommerce.Core.Email;
using cloudCommerce.Core.IO;
using cloudCommerce.Core.Logging;
using cloudCommerce.Services.Messages;

namespace cloudCommerce.Services.DataExchange.Export.Deployment
{
	public class EmailFilePublisher : IFilePublisher
	{
		private IEmailAccountService _emailAccountService;
		private IQueuedEmailService _queuedEmailService;

		public EmailFilePublisher(
			IEmailAccountService emailAccountService,
			IQueuedEmailService queuedEmailService)
		{
			_emailAccountService = emailAccountService;
			_queuedEmailService = queuedEmailService;
		}

		public virtual void Publish(ExportDeploymentContext context, ExportDeployment deployment)
		{
			var emailAccount = _emailAccountService.GetEmailAccountById(deployment.EmailAccountId);
			var smtpContext = new SmtpContext(emailAccount);
			var count = 0;

			foreach (var email in deployment.EmailAddresses.SplitSafe(",").Where(x => x.IsEmail()))
			{
				var queuedEmail = new QueuedEmail
				{
					From = emailAccount.Email,
					FromName = emailAccount.DisplayName,
					SendManually = false,
					To = email,
					Subject = deployment.EmailSubject.NaIfEmpty(),
					CreatedOnUtc = DateTime.UtcNow,
					EmailAccountId = deployment.EmailAccountId
				};

				foreach (var path in context.GetDeploymentFiles())
				{
					var name = Path.GetFileName(path);

					queuedEmail.Attachments.Add(new QueuedEmailAttachment
					{
						StorageLocation = EmailAttachmentStorageLocation.Blob,
						Data = File.ReadAllBytes(path),
						Name = name,
						MimeType = MimeTypes.MapNameToMimeType(name)
					});
				}

				_queuedEmailService.InsertQueuedEmail(queuedEmail);
				++count;
			}

			context.Log.Information("{0} email(s) created and queued for deployment.".FormatInvariant(count));
		}
	}
}
