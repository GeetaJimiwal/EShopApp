using Microsoft.AspNetCore.Mvc;
using WebApplication1.Db;
using WebApplication1.Model;
using WebApplication1.Repository;
using Microsoft.AspNetCore.Authorization;
using WebApplication1.Services;
using AutoMapper;
using WebApplication1.EntityModel;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreadentialController : Controller
    { 
        private IUserRepository userRepository;
        private IUserCreadentialService userCreadentialService;
        private readonly IMapper mapper;
        public CreadentialController(IUserCreadentialService userCreadentialService,IMapper mapper, IUserRepository userRepository)
        {
            this.userCreadentialService = userCreadentialService;
            this.userRepository = userRepository;
            this.mapper = mapper;

        }
        [HttpGet]

        public IEnumerable<UserCreadentialEntity> Get()
        {
            var users = userCreadentialService.GetAll();
            var userentity = mapper.Map<List<UserCreadentialEntity>>(users);
            return userentity;
        }
        [HttpGet("{id}")]

        public UserCreadential Get (int id)
        {
            var users = userCreadentialService.GetById(id);
            return users;
        }
        [HttpPost]
        [AllowAnonymous]
        [Produces("application/json")]

        public async void Post (UserCreadentialEntity  Creadential)
        {
            var encryptedpassword = userCreadentialService.EncryptedPassword(Creadential.Password);
            Creadential.Password = (string)encryptedpassword;
            var userentity =  mapper.Map<UserCreadential>(Creadential);
            userCreadentialService.Create(userentity);

        }
       /* [HttpPut]

        public async void Put(string email, string password)
        {
            var updatedEmail = userRepository.GetByEmail(email);
             var updatedPassword = _userCreadential.AddData((User)updatedEmail);
            _userCreadential.Create(updatedPassword);
            

        }*/
        

    }
}
 
