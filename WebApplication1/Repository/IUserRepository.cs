using WebApplication1.Model;

namespace WebApplication1.Repository
{
    public interface IUserRepository
    {
        public User GetById (int id);
        public List<User> GetAll();
        public User Create(User user);

        User Authenticate(string userName, string password);
        string EncryptedPassword(string password);
        object GetByEmail(string email);
        /*string  GetByEmail(string email);*/
    }
}
