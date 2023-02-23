using WebApplication1.Model;
using MimeKit;
using System.IO;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit.Text;
using Microsoft.Extensions.Options;
using WebApplication1.Services;
 
 
namespace WebApplication1.Services
{
    public class MailService : IMailService
    {
        private IConfiguration configuration;
         public MailService(IConfiguration configuration)
         {
            this.configuration = configuration;
         }

        public void SendEmail(EmailDto request)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(configuration.GetSection("EmailUserName").Value));
            email.To.Add(MailboxAddress.Parse(request.To));
            email.Subject = request.Subject; 
            email.Body = new TextPart(TextFormat.Html) { Text = request.Body };
            using var smtp = new SmtpClient();
            smtp.Connect(configuration.GetSection("EmailHost").Value , 435, SecureSocketOptions.StartTls);
            smtp.Authenticate(configuration.GetSection("EmailUserName").Value, configuration.GetSection("EmailPassword").Value);
            smtp.Send(email);
            smtp.Disconnect(true);
        }
    }
}
