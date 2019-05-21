using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace EmailServiceProvider.Services
{
    public class EmailService
    {
        public static void SendEmail(string fromAddress,
            string toAddresses,
            string ccAddresses,
            string bccAddresses,
            string subject,
            string body,
            IList<MailAttachment> attachments)
        {
            try
            {
                // from and to addresses are required
                if (string.IsNullOrWhiteSpace(fromAddress) || string.IsNullOrWhiteSpace(toAddresses))
                {
                    return;
                }

                using (var smtpClient = new SmtpClient())
                {
                    using (var mailMessage = new MailMessage())
                    {
                        // From
                        mailMessage.From = new MailAddress(fromAddress);

                        // Tos
                        var toMailAddresses = toAddresses.Split(';');
                        foreach (var mailAddress in toMailAddresses)
                        {
                            mailMessage.To.Add(mailAddress);
                        }

                        // CCs
                        if (!string.IsNullOrWhiteSpace(ccAddresses))
                        {
                            var ccMailAddresses = ccAddresses.Split(';');
                            foreach (var mailAddress in ccMailAddresses)
                            {
                                mailMessage.CC.Add(mailAddress);
                            }
                        }

                        // BCCs
                        if (!string.IsNullOrWhiteSpace(bccAddresses))
                        {
                            var bccMailAddresses = bccAddresses.Split(';');
                            foreach (var mailAddress in bccMailAddresses)
                            {
                                mailMessage.Bcc.Add(mailAddress);
                            }
                        }

                        mailMessage.Subject = subject;
                        mailMessage.Body = body;
                        mailMessage.IsBodyHtml = true;

                        // Attachments
                        foreach (var attchment in attachments)
                        {
                            mailMessage.Attachments.Add(attchment.File);
                        }

                        smtpClient.Send(mailMessage);
                    }
                }
            }
            catch (Exception)
            {
                var sb = new StringBuilder();
                sb.Append("\nFrom:" + fromAddress);
                sb.Append("\nTo:" + toAddresses);
                sb.Append("\nbody:" + body);
                sb.Append("\nsubject:" + subject);
            }
        }

        public async static void SendEmailAsync(string fromAddress,
            string toAddresses,
            string ccAddresses,
            string bccAddresses,
            string subject,
            string body,
            IList<MailAttachment> attachments)
        {
            try
            {
                // from and to addresses are required
                if (string.IsNullOrWhiteSpace(fromAddress) || string.IsNullOrWhiteSpace(toAddresses))
                {
                    return;
                }

                using (var smtpClient = new SmtpClient())
                {
                    using (var mailMessage = new MailMessage())
                    {
                        // From
                        mailMessage.From = new MailAddress(fromAddress);

                        // Tos
                        var toMailAddresses = toAddresses.Split(';');
                        foreach (var mailAddress in toMailAddresses)
                        {
                            mailMessage.To.Add(mailAddress);
                        }

                        // CCs
                        if (!string.IsNullOrWhiteSpace(ccAddresses))
                        {
                            var ccMailAddresses = ccAddresses.Split(';');
                            foreach (var mailAddress in ccMailAddresses)
                            {
                                mailMessage.CC.Add(mailAddress);
                            }
                        }

                        // BCCs
                        if (!string.IsNullOrWhiteSpace(bccAddresses))
                        {
                            var bccMailAddresses = bccAddresses.Split(';');
                            foreach (var mailAddress in bccMailAddresses)
                            {
                                mailMessage.Bcc.Add(mailAddress);
                            }
                        }

                        mailMessage.Subject = subject;
                        mailMessage.Body = body;
                        mailMessage.IsBodyHtml = true;

                        // Attachments
                        if (attachments != null && attachments.Count > 0)
                        {
                            foreach (var attchment in attachments)
                            {
                                mailMessage.Attachments.Add(attchment.File);
                            }
                        }

                        await smtpClient.SendMailAsync(mailMessage);
                    }
                }
            }
            catch (Exception)
            {
                var sb = new StringBuilder();
                sb.Append("\nFrom:" + fromAddress);
                sb.Append("\nTo:" + toAddresses);
                sb.Append("\nbody:" + body);
                sb.Append("\nsubject:" + subject);
            }
        }

    }
}