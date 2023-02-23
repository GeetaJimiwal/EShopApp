using WebApplication1.Model;


namespace WebApplication1.Repository
{
    public interface IProductRepository
    {
          Product GetById(int id);
         /* Product GetByCategory(Category category);*/
         List<Product> GetAll();
          Product Create(Product product);
        List<Product> GetCategory(string product);
        
    }
}
