using System.Data.Entity;
using WebApplication1.Db;
using WebApplication1.Model;
using WebApplication1.Repository;

namespace WebApplication2.RepositoryMockUP
{

    public class MoqProductRepo : IProductRepository
    {
        
        public Product Create(Product product)
        {
             return product;
        }

        public List<Product> GetAll()
        {
             return new List<Product>();
        }

        public Product GetById(int id)
        {
            throw new NotImplementedException();
        }

        /*public Product GetById(int id)
        {
            return  ;
        }*/
    }
}
