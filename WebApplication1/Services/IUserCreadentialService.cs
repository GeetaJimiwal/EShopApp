using WebApplication1.Model;

namespace WebApplication1.Services
{
    public interface IUserCreadentialService
    {
        UserCreadential GetById(int id);
        List<UserCreadential> GetAll();
        UserCreadential Create(UserCreadential userCreadential);
        UserCreadential AddData(User user);
        string EncryptedPassword(string password);
        /* UserCreadential Authenticate(string userName, string email);*/
        List<Model.UserCreadential> GetByEmail(string email);
    }
}
