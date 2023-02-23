using WebApplication1.Repository;

namespace WebApplication1.Services
{
    public interface IEmailsender
    {
       Task SendEmailAsync(string email, string subject, string htmlMessage);
         
 
    }
}
