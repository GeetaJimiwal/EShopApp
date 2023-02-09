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
        [HttpPost("Send")]
        public async Task<IActionResult> Send([FromBody] MailRequest request)
        {
            try
            {
                await mailService.SendEmailAsync(request);
                return Ok();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
