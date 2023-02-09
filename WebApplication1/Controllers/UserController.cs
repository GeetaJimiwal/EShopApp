using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using WebApplication1.Db;
using WebApplication1.Model;
using WebApplication1.Repository;

namespace WebApplication1.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository userRepository;
        private readonly ProductContext productContext;
        public UserController(IUserRepository userRepository,ProductContext productContext)
        {
            this.userRepository = userRepository;
            this.productContext = productContext;
        }

        [HttpGet]
        public IEnumerable<User> Get()
        {
            var users = userRepository.GetAll();
            return users;
        }
        [HttpGet("{id}")]
        public  User  Get(int id)
        {
             var user = userRepository.GetById(id);
            return user;
        }
        [HttpPost("SignUp")]
        [AllowAnonymous]
        [Produces("application/json")]
        public IResult  Signup(User user)
        {
            var isEmailAlreadyExists = productContext.User.Any(x => x.Email == user.Email);
            if (isEmailAlreadyExists)
            {
                ModelState.AddModelError("Email", "User with this email already exists");
                return (IResult)user;
            }
           /* User newobj = new User();
            newobj.Name = user.Name;
            newobj.Email = user.Email;
            newobj.Password = user.Password;
            productContext.User.Add(newobj);
            productContext.SaveChanges();*/
            var encryptedpassword = userRepository.EncryptedPassword(user.Password);
            user.Password = (string)encryptedpassword;
            var userResponse= userRepository.Create(user);
            if (userResponse != null)
            {
                return Results.Ok(user.Equals(userResponse));
            }
            return Results.Ok(false);

        }


    }
}
