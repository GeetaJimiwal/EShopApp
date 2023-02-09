using Microsoft.AspNetCore.Mvc;
using WebApplication1.Db;
using WebApplication1.Model;
using WebApplication1.Repository;
using Microsoft.AspNetCore.Authorization;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreadentialController : Controller
    {
        private IUserCreadential _userCreadential;
        private IUserRepository userRepository;

        public CreadentialController(IUserCreadential _userCreadential, IUserRepository userRepository)
        {
            this._userCreadential = _userCreadential;
            this.userRepository = userRepository;
        }
        [HttpGet]

        public IEnumerable<UserCreadential> Get()
        {
            var users = _userCreadential.GetAll();
            return users;
        }
        [HttpGet("{id}")]

        public UserCreadential Get (int id)
        {
            var users = _userCreadential.GetById(id);
            return users;
        }
        [HttpPost]
        [AllowAnonymous]
        [Produces("application/json")]

        public async void Post (UserCreadential userCreadential)
        {
            var encryptedpassword = userRepository.EncryptedPassword(userCreadential.Password);
            userCreadential.Password = (string)encryptedpassword;
            _userCreadential.Create(userCreadential);

        }
        [HttpPut]

        public async void Put(string email, string password)
        {
            var updatedEmail = userRepository.GetByEmail(email);
             var updatedPassword = _userCreadential.AddData((User)updatedEmail);
            _userCreadential.Create(updatedPassword);
            

        }
        

    }
}
 
