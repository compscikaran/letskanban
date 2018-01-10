using letskanban.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace letskanban.Services
{
    public class Mailer
    {
        private Story _story;
        private ApplicationDbContext _context;

        public Mailer(Story story)
        {
            this._story = story;
            this._context = new ApplicationDbContext();
        }
        public void SendStoryReminder()
        {
            var client = new SmtpClient("");
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential("","");
            var mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("admin@letskanban.com");
            var user = _context.Users.First(m => m.UserName == _story.UserName);
            mailMessage.To.Add(user.Email);
            mailMessage.Body = _story.Description + "\n" + _story.DueDate + "\n" + _story.Priority;
            mailMessage.Subject = "Urgent Story Pending" + _story.Name;
            client.Send(mailMessage);
        }
    }
}
