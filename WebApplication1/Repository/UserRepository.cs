using Microsoft.EntityFrameworkCore;
using System.Text;
using WebApplication1.Db;
using WebApplication1.Model;

namespace WebApplication1.Repository
{
    public class UserRepository:IUserRepository
    {
        private readonly ProductContext dbContext;
        private readonly DbSet<User> user;
        public UserRepository(ProductContext dbContext)
        {
            this.dbContext = dbContext;
            user = dbContext.Set<User>();
        }

        public User Authenticate(string userName, string password)
        {
            return dbContext.User.FirstOrDefault(x => x.Name == userName && x.Password == password);
        }

        public User Create(User user)
        {
             dbContext.Add(user);
            dbContext.SaveChanges();
            return user;
        }

        public List<User> GetAll()
        {
            return this.user.AsQueryable().ToList();
        }

        public object GetByEmail(string email)
        {
            return dbContext.User.FirstOrDefault(x => x.Email == email);
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
    }
}
