using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using WebApplication1.Db;
using WebApplication1.Model;
using WebApplication1.Repository;
using WebApplication1.EntityModel;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly ProductContext productContext;
        private readonly Repository.IUserCreadential  userCreadential;
        private readonly IUseService userService;
        private readonly IMapper _mapper;
        public UserController(Repository.IUserCreadential userCreadential, IUseService userService, IMapper mapper,ProductContext productContext)
        {
           this.userCreadential = userCreadential;
            this.userService = userService;
            this._mapper = mapper;
            this.productContext = productContext;
        }

        [HttpGet]
        public IEnumerable<UserEntity> Get()
        {
            var users = userService.GetAll();
            var userEntityModels = _mapper.Map<List<UserEntity>>(users);
            return userEntityModels;
        }
        [HttpGet("{id}")]
        public List<UserEntity>  Get(int id)
        {
            var userById = new List<UserEntity>();
            var users = userService.GetAll();
            var usersEntity = _mapper.Map<List<UserEntity>>(users); 
            foreach (var user in usersEntity)
            {
                if (user.Id == id)
                {
                    userById.Add(user);
                }
            }
            return userById;
        }
        [HttpPost("SignUp")]
        [AllowAnonymous]
        [Produces("application/json")]
        public IResult  Signup(UserEntity userEntity)
        {

            var isEmailAlreadyExists = productContext.User.Any(x => x.Email == userEntity.Email);

            if (!isEmailAlreadyExists)
            {
                var encryptedpassword = userService.EncryptedPassword(userEntity.Password);
                userEntity.Password = (string)encryptedpassword;
                var users = _mapper.Map<User>(userEntity);
                var userResponse = userService.Create(users);
                return Results.Ok(users.Equals(userResponse));

            }
            else
            {
                return Results.BadRequest();
            }
            /*var emailvalidation = userService.GetByEmail(userEntity.Email);
            userEntity.Email = emailvalidation.Email;
            var encryptedPassword = userService.EncryptedPassword(userEntity.Password);
            userEntity.Password = encryptedPassword;
            *//*var emails = userService.GetByEmail(userEntity.Email);
            userEntity.Email = emails;*//*
            var user = _mapper.Map<User>(userEntity);
            var userCreated = userService.Create(user);
            if(userCreated == null)
            {
                return Results.Ok(user.Email);
            }
            return Results.BadRequest();*/

        }


    }
}
