using Azure;
using Azure.Core;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;
using Org.BouncyCastle.Asn1.Ocsp;
using WebApplication1.Model;
using WebApplication1.Repository;
using WebApplication1.Services;
using Microsoft.AspNetCore.Diagnostics;
using System.Text;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly ISecurityService _securityService;
        private readonly ILoginRepository loginRepository;
      

        public AuthenticationController(ISecurityService securityService, ILoginRepository loginRepository)
        {
            _securityService = securityService;
            this.loginRepository = loginRepository;
             
        }
        [HttpGet]
        public IEnumerable<LoginRequest> Get()
        {
            var loginUser = loginRepository.GetAll();
            return loginUser;
        }
        [HttpGet("{id}")]
        public LoginRequest Get(int id)
        {
            var loginUser = loginRepository.GetById(id);
            return loginUser;
        }

        [HttpPost("/signin")]
        [AllowAnonymous]
        [Produces("application/json")]



        public async Task<IResult> SignIn(LoginRequest request)
        {

            bool isValid = false;
            string token;
           (isValid, token) =_securityService.ValidateUser(request);

           return isValid? Results.Ok(token): Results.Unauthorized();

        }

       
        
    }
}
