using EmailServiceProvider.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EmailServiceProvider.Services;

namespace EmailServiceProvider.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View(new MailViewModel());
        }

        [HttpPost]
        public ActionResult Index(MailViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var mailAttachments = new List<MailAttachment>();
            if (model.Attachments != null && model.Attachments.Any())
            {
                foreach (var attachment in model.Attachments)
                {
                    mailAttachments.Add(new MailAttachment(attachment.InputStream, attachment.FileName));
                }
            }

            EmailService.SendEmail(model.From, model.To, model.Cc, model.Bcc, model.Subject, model.Body, mailAttachments);

            return View(new MailViewModel());
        }
    }
}