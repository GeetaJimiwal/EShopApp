using System.Text;
using WebApplication1.Db;
using WebApplication1.EntityModel;
using WebApplication1.Model;
using WebApplication1.Repository;

namespace WebApplication1.Services
{
    public class UserService : IUseService
    {
        private readonly ProductContext productContext;
        private IUserRepository userRepository;

        public UserService(IUserRepository userRepository, ProductContext productContext)
        {
            this.userRepository = userRepository;
            this.productContext = productContext;
        }
        public User Authenticate(string userName, string password)
        {
            var authentication = userRepository.Authenticate(userName, password);
            return authentication;
        }

        public User Create(User user)
        {
            user.IsActive = true;
            user.CreatedAt = DateTime.Now;
            user.UpdatedAt = DateTime.Now;
            user.UpdatedBy = 1;
            user.CreatedBy = 1;
            
            user = userRepository.Create(user);
            return user;
        }

        public string EncryptedPassword(string password)
        {
             var encryptedPassword = userRepository.EncryptedPassword(password);
            return encryptedPassword;
        }

        public List<User> GetAll()
        {
            var user = userRepository.GetAll();
            return user;
        }

         

        public User GetById(int id)
        {
           var userId= userRepository.GetById(id);
            return userId;
        }

           
        User IUseService.GetByEmail(string email)
          
        {
           var emailvalidation = userRepository.GetByEmail(email);
            return emailvalidation;
           
        }
    }
}
