using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace EmailServiceProvider.Models
{
    public class MailViewModel
    {
        [Required]
        public string From { get; set; }
        [Required]
        public string To { get; set; }
        public string Cc { get; set; }
        public string Bcc { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        public string Body { get; set; }
        public List<HttpPostedFileBase> Attachments { get; set; }
    }
}