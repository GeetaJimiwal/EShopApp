using WebApplication1.Model;

namespace WebApplication1.Repository
{
    public interface ILoginRepository
    {
        LoginRequest GetById(int id);
        List<LoginRequest> GetAll();
        LoginRequest Create (LoginRequest loginrequest);
        string DecryptedPassword(string password);


        /*  string DecryptedPassword(string password);*/
        /* string EncryptedPassword(string password);*/

        /* public List<LoginRequest> GetAll();
public LoginRequest Create(LoginRequest loginRequest);*/
    }
}
