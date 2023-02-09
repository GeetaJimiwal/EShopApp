using System.IdentityModel.Tokens.Jwt;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using WebApplication1.Model;
using WebApplication1.Repository;

namespace WebApplication1.Services
{
    

    public class SecurityService : ISecurityService
    {
        private readonly IConfiguration _configuration;
        private readonly ILoginRepository loginRepository;
        private readonly IUserRepository userRepository;

        
        public SecurityService(IConfiguration configuration,ILoginRepository loginRepository,IUserRepository userRepository)
        {
            _configuration = configuration;
           this.loginRepository = loginRepository;
           this.userRepository = userRepository;
        }
        public (bool isValid, string token) ValidateUser()
        {
            throw new NotImplementedException();
        }

        (bool, string) ISecurityService.ValidateUser(LoginRequest loginDetails)
        {
            var encrypted = userRepository.EncryptedPassword(loginDetails.Password);
            loginDetails.Password = encrypted ;
            var user = userRepository.Authenticate(loginDetails.Name, loginDetails.Password);
            if (user == null)
            {
                return (false, "");
            }
            var issuer = _configuration["Jwt:Issuer"];
            var audience = _configuration["Jwt:Audience"];
            var key = Encoding.ASCII.GetBytes
                (_configuration["Jwt:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                        new Claim("Id", Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Sub, loginDetails.Name),
                        new Claim(JwtRegisteredClaimNames.Email, loginDetails.Name),
                        new Claim(JwtRegisteredClaimNames.Jti,
                            Guid.NewGuid().ToString())
                    }),

                Expires = DateTime.UtcNow.AddMinutes(5),
                Issuer = issuer,
                Audience = audience,
                SigningCredentials = new SigningCredentials
                (new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha512Signature)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = tokenHandler.WriteToken(token);
            var stringToken = tokenHandler.WriteToken(token);
            return (true, stringToken);
        }
        

    }
}
