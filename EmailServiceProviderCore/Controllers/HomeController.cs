using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using EmailServiceProviderCore.Models;
using EmailServiceProviderCore.Services;
using System.IO;

namespace EmailServiceProviderCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmailService _emailService;

        public HomeController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        public IActionResult Index()
        {
            return View(new MailViewModel());
        }

        [HttpPost]
        public IActionResult Index(MailViewModel model)
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
                    using(var memoryStream = new MemoryStream()) { 
                        attachment.CopyTo(memoryStream);
                        mailAttachments.Add(new MailAttachment(memoryStream.ToArray(), attachment.FileName));
                    }
                }
            }

            _emailService.SendEmail(model.From, model.To, model.Cc, model.Bcc, model.Subject, model.Body, mailAttachments);

            return View(new MailViewModel());
        }
    }
}
