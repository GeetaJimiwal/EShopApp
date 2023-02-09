using Microsoft.EntityFrameworkCore;
 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Db
{
    public class ProductContext : DbContext
    {
        public ProductContext()
        {
        }
        public ProductContext(DbContextOptions<ProductContext> options)
         : base(options)
        {
        }
        public DbSet<Model.Product> Product { get; set; }
        
        public DbSet<Model.User> User { get; set; }
        public DbSet<Model.UserCreadential>userCreadential { get; set; }

         
    }
}
