using System.Collections.Generic;

namespace EmailServiceProviderCore.Services
{
    public interface IEmailService
    {
        void SendEmail(string fromAddress,
            string toAddresses,
            string ccAddresses,
            string bccAddresses,
            string subject,
            string body,
            IList<MailAttachment> attachments);
    }
}
