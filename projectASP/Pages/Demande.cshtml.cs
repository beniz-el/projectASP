using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using projectASP.Models;

namespace projectASP.Pages
{
    public class DemandeModel : PageModel
    {
        public EmailClass emailClass { get; set; }
        public String Msg;
        public void OnGet()
        {
        }

        [HttpPost]
        public ActionResult OnPost(EmailClass emailClass)
        {
            MailMessage mm = new MailMessage("elbekrizineb97@gmail.com", "elbekrizineb97@gmail.com");
            mm.Subject = "Demande";
            mm.Body = "CIN: "+emailClass.CIN+"\nJe veux le document suivant: "+emailClass.mail;
            mm.IsBodyHtml = false;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;

            NetworkCredential nc = new NetworkCredential("elbekrizineb97@gmail.com", "Zineb@elbekri/1");
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = nc;
            smtp.Send(mm);
            Msg = "Yous email was sent successfully";
            return Page();
        }
    }
}
