using WebApplication1.Model;


namespace WebApplication1.Repository
{
    public interface IProductRepository
    {
        public Product GetById(int id);
        public List<Product> GetAll();
        public Product Create(Product product);
        
    }
}
