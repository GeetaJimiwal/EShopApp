using System.Text;
using WebApplication1.Model;
using WebApplication1.Repository;

namespace WebApplication1.Services
{
    public class UserService : IUseService
    {
        private IUserRepository _repository;

        public UserService(IUserRepository userRepository)
        {
            _repository = userRepository;
        }
        public User Authenticate(string userName, string password)
        {
            var authentication = _repository.Authenticate(userName, password);
            return authentication;
        }

        public User Create(User user)
        {
            user.Name = "ggg";
            user.IsActive = true;
             user.CreatedAt = DateTime.Now;
            user.UpdatedAt = DateTime.Now;
            
            user = _repository.Create(user);
            return user;
        }

        public string EncryptedPassword(string password)
        {
             var encryptedPassword = _repository.EncryptedPassword(password);
            return encryptedPassword;
        }

        public List<User> GetAll()
        {
            var user = _repository.GetAll();
            return user;
        }

       /* public string GetByEmail(string email)
        {

            var emails = _repository.GetByEmail();
            return emails;
        }*/

        public User GetById(int id)
        {
           var userId= _repository.GetById(id);
            return userId;
        }
    }
}
