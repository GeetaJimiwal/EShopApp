using WebApplication1.Model;

namespace WebApplication1.Services
{
    public interface IUseService
    {
         User GetById(int id);
         List<User> GetAll();
          User Create(User user);

        public User Authenticate(string userName, string password);
        string EncryptedPassword(string password);
        /*     object GetByEmail(string email);*/
        User GetByEmail(string email);
    }
}
