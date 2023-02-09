using WebApplication1.Model;

namespace WebApplication1.Services
{
    public interface IUseService
    {
        public User GetById(int id);
        public List<User> GetAll();
        public User Create(User user);

        User Authenticate(string userName, string password);
        string EncryptedPassword(string password);
   /*     object GetByEmail(string email);*/
        /*User GetByEmail(string email);*/
    }
}
