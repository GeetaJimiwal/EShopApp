using Microsoft.EntityFrameworkCore;
using ECOMMERCEAPP.ProductDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
 

namespace ECOMMERCEAPP.Repository
{
    public class ProductRepository:IProductRepository
    {
        private readonly ProductContext dbContext;
        private readonly DbSet<Model.Product> entities;
        public ProductRepository(ProductContext dbContext)
        {
           this.dbContext = dbContext;
            this.entities= dbContext.Set<Model.Product>();

        }

         public Model.Product Create(Model.Product product)
        {
            throw new NotImplementedException();
        }
        public List<Model.Product> GetAll()
        {
            return this.entities.AsQueryable().ToList();
        }

         public Model.Product GetById(int id)
        {
            return entities.Find(id);
        }
    }
}
 
