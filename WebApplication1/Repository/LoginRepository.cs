using Microsoft.EntityFrameworkCore;
using System.Text;
using WebApplication1.Db;
using WebApplication1.Model;

namespace WebApplication1.Repository
{
    public class LoginRepository:ILoginRepository
    {
        private readonly ProductContext dbContext;
        private readonly DbSet<LoginRequest> loginRequests;

        public LoginRepository(ProductContext dbContext)
        {
            this.dbContext = dbContext;
            loginRequests = dbContext.Set<LoginRequest>();
        }


        public LoginRequest Create(LoginRequest loginrequest)
        {
           dbContext.Add(loginrequest);
           dbContext.SaveChanges();
            return loginrequest;
        }

        public string DecryptedPassword(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                return null
;
            }
            else
            {
                byte[] encrptedPasssword = Convert.FromBase64String(password);
                string decryptedPassword = ASCIIEncoding.ASCII.GetString(encrptedPasssword);
                return decryptedPassword;
            }
        }

        public List<LoginRequest> GetAll()
        {
             return loginRequests.AsQueryable().ToList();
        }

        public LoginRequest GetById(int id)
        {
            return loginRequests.Find(id);
        }

        

       
    }
}
