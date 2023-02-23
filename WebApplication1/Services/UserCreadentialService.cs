using WebApplication1.Model;
using WebApplication1.Repository;

namespace WebApplication1.Services
{
    public class UserCreadentialService : IUserCreadentialService
    {
        private readonly IUserCreadential userCreadentiaRepository;
        public UserCreadentialService(IUserCreadential userCreadentiaRepository)
        {
            this.userCreadentiaRepository = userCreadentiaRepository;
        }

        public UserCreadential AddData(User user)
        {
            throw new NotImplementedException();
        }

       /* public UserCreadential Authenticate(string userName, string email)
        {
            var usercreadential = userCreadentiaRepository.Authenticate(userName,email);
            return usercreadential;

        }*/

        public UserCreadential Create(UserCreadential userCreadential)
        {
             userCreadential.CreatedAt = DateTime.Now;
              userCreadential.UpdatedAt= DateTime.Now;
            userCreadential.Email = "hgkdfjghd";
            userCreadential.IsActive = true;
            userCreadential = userCreadentiaRepository.Create(userCreadential);
            return userCreadential;
        }

        public string EncryptedPassword(string password)
        {
            var user =  userCreadentiaRepository.EncryptedPassword(password);
            return user;
        }

        public List<UserCreadential> GetAll()
        {
             var users =  userCreadentiaRepository.GetAll();
            return users;
        }

        public List<UserCreadential> GetByEmail(string email)
        {
            var credential = userCreadentiaRepository.GetByEmail(email);
            return credential;
        }

        public UserCreadential GetById(int id)
        {
            var user = userCreadentiaRepository.GetById(id);
            return user;
        }
    }
}
