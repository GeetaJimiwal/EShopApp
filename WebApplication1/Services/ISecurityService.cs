using WebApplication1.Model;

namespace WebApplication1.Services
{
    public interface ISecurityService
    {
        (bool, string) ValidateUser(LoginRequest loginDetails);
        (bool isValid, string token) ValidateUser();
    }
}
