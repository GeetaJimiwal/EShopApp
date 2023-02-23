using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Text;
using WebApplication1.Db;
using WebApplication1.EntityModel;
using WebApplication1.Model;
using WebApplication1.Services;

namespace WebApplication1.Repository
{
    public class UserRepository:IUserRepository
    {
        private readonly ProductContext dbContext;
        private readonly DbSet<User> user;
      
        public UserRepository(ProductContext dbContext )
        {
            this.dbContext = dbContext;
            user = dbContext.Set<User>();
             
        }

        public User Authenticate(string userName, string password)
        {
            var authenticateuser = dbContext.User.FirstOrDefault(x => x.Name == userName && x.Password == password);
            return authenticateuser;
        }

        public User Create(User user)
        {
            /*var isEmailAlreadyExists = dbContext.User.Any(x => x.Email == user.Email);

            if (!isEmailAlreadyExists)
            {
                dbContext.Add(user);

            }
            else
            {
                return null;
            }*/
            dbContext.Add(user);
            try
            {
                dbContext.SaveChanges();
            }
            catch (Exception)
            {
                return null;
            }
            return user;
            
          
        }

        public List<User> GetAll()
        {
            return user.AsQueryable().ToList();
        }

        

        /*   public string GetByEmail(string email)
           {
               return this.user.FindAsync().Equals()
           }*/

        public User GetById(int id)
        {
            return user.Find(id);
        }
        string IUserRepository.EncryptedPassword(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                return null
;
            }
            else
            {
                byte[] storePasssword = ASCIIEncoding.ASCII.GetBytes(password);
                string ecryptedPassword = Convert.ToBase64String(storePasssword);
                return ecryptedPassword;
            }
        }

        public User GetByEmail(string email)
        {
            return dbContext.User.FirstOrDefault(x => x.Email == email);
        }

    }
}
