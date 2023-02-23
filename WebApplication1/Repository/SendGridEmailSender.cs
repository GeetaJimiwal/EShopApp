using SendGrid;
using SendGrid.Helpers.Mail;
using WebApplication1.Model;

namespace WebApplication1.Repository
{
    public class SendGridEmailSender : IEmailSender
    {
        private readonly   ISendGridClient sendGridClient;
        private readonly ILogger logger;

        public SendGridEmailSender(ISendGridClient sendGridClient,ILogger<SendGridEmailSender> logger )
        {
             this.sendGridClient = sendGridClient;
            this.logger = logger;
        }

        public  async Task SendEmailAsync(string toEmail, string subject, string message)
        {
            
            var msg = new SendGridMessage()
            {
                From = new EmailAddress("geeta.borajimiwal@xcdify.com", "geeta"),
                Subject = subject,
                PlainTextContent = message,
                HtmlContent = message,
            };
            msg.AddTo(new EmailAddress(toEmail));

            var response =await sendGridClient.SendEmailAsync(msg);
            if (response.IsSuccessStatusCode)
            {
                logger.LogInformation("email queued suceesfully");
            }
            else
            {
                logger.LogError("Failed to send email");
            }

           
        }
    }
}
