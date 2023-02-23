using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Text;
using WebApplication1.Db;
using WebApplication1.EntityModel;
using WebApplication1.Model;

namespace WebApplication1.Repository
{
    public class UserCreadentialRepository : IUserCreadential
    {
        private readonly ProductContext dbContext;
        private readonly DbSet<UserCreadential> userCreadential;
        

        public UserCreadentialRepository(ProductContext dbContext)
        {
            this.dbContext = dbContext;
            userCreadential = dbContext.Set<UserCreadential>();
           
        }

       /* public UserCreadential Authenticate(string email, string userName)
        {
            var authenticateuser = dbContext.userCreadential.FirstOrDefault(x => x.Name == userName && x.Email == email);
            return authenticateuser;
        }*/

        public UserCreadential Create(UserCreadential userCreadential)
        {
            dbContext.Add(userCreadential);
            dbContext.SaveChanges();
            return userCreadential;
        }

        public string EncryptedPassword(string password)
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

        public List<UserCreadential> GetAll()
        {
           return userCreadential.AsQueryable().ToList();
        }

        public List<UserCreadential> GetByEmail(string email)
        {
            return dbContext.userCreadential.Where(x => x.Email == email).ToList();
        }

        public UserCreadential GetById(int id)
        {
            return userCreadential.Find(id);
        }

        UserCreadential IUserCreadential.AddData(User user)
        {
            var userCreadentialdata = new UserCreadential();
            userCreadentialdata.UserId = user.Id;
            userCreadentialdata.Name = user.Name;
            userCreadentialdata.Email = user.Email;
            userCreadentialdata.Password = user.Password;
            userCreadentialdata.IsActive = false;
            userCreadentialdata.CreatedAt = DateTime.Now;
            userCreadentialdata.UpdatedAt = DateTime.Now;
            userCreadentialdata.CreatedBy = user.CreatedBy;
            userCreadentialdata.UpdatedBy = user.UpdatedBy;

            return userCreadentialdata;
        }
    }
}
