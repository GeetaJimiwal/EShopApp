﻿using Microsoft.EntityFrameworkCore;
using WebApplication1.Db;
using WebApplication1.Model;
namespace WebApplication1.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductContext dbContext;
        private readonly DbSet<Product> products;

        public ProductRepository(ProductContext dbContext)
        {
            this.dbContext = dbContext;
            this.products = dbContext.Set<Product>();
        }

        public Product Create(Product product)
        {
            throw new NotImplementedException();
        }
        public List<Product> GetAll()
        {
            return this.products.AsQueryable().ToList();
        }
        public Product GetById(int id)
        {
            return products.Find(id);
        }
    }
}
