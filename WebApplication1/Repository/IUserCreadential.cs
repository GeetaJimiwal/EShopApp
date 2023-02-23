
using WebApplication1.Model;

namespace WebApplication1.Repository
{
    public interface IUserCreadential
    {
        UserCreadential GetById(int id);
        List<UserCreadential> GetAll();
        UserCreadential Create (UserCreadential userCreadential);
        UserCreadential AddData(User user);
        List<Model.UserCreadential> GetByEmail(string email);
        /*UserCreadential Authenticate( string userName, string email);*/
        string EncryptedPassword(string password);
    }
}
