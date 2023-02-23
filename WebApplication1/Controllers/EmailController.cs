using Microsoft.AspNetCore.Mvc;
using WebApplication1.Model;
using WebApplication1.Services;
namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmailController : Controller
    {
        private readonly IMailService mailService;
        public EmailController(IMailService mailService)
        {
            this.mailService = mailService;
        }
        [HttpPost]
        public IActionResult SendEmail(EmailDto request)
        {
            mailService.SendEmail(request);
            return Ok();
        }
    }
}
