using Microsoft.EntityFrameworkCore;
using WebApplication1.Db;
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

        public UserCreadential Create(UserCreadential userCreadential)
        {
            dbContext.Add(userCreadential);
            dbContext.SaveChanges();
            return userCreadential;
        }
        public UserCreadential AddData(User user)
        {
            var userCreadentialdata = new UserCreadential();
            userCreadentialdata.UserId = user.Id;
            userCreadentialdata.Name = user.Name;
            userCreadentialdata.Email = user.Email;
            userCreadentialdata.Password = user.Password;
            userCreadentialdata.IsActive =false;
            userCreadentialdata.CreatedAt = DateTime.Now;
            userCreadentialdata.UpdatedAt = DateTime.Now;
            userCreadentialdata.CreatedBy = user.CreatedBy;
            userCreadentialdata.UpdatedBy = user.UpdatedBy;

            return userCreadentialdata;


        }
        public List<UserCreadential> GetAll()
        {
           return userCreadential.AsQueryable().ToList();
        }

        public UserCreadential GetById(int id)
        {
            return userCreadential.Find(id);
        }
    }
}
