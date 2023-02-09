using WebApplication1.Model;

namespace WebApplication1.Services
{
    public interface IProductService
    {
        public Product GetById(int id);
        public List<Product> GetAll();
        public Product Create(Product product);
    }
}
