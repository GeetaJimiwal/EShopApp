using WebApplication1.Model;
using System.Threading.Tasks;
namespace WebApplication1.Services
{
    public interface IMailService
    {
         void SendEmail(EmailDto request);
    }
}
