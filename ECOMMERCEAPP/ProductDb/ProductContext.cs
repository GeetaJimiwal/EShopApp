using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ECOMMERCEAPP.ProductDb
{
    public class ProductContext:DbContext
    {
        public ProductContext(DbContextOptions<ProductContext>options)
            : base(options)
        {

        }
        public DbSet<Model.Product> Products { get; set; }
    }
}
