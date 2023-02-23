using WebApplication1.Model;

namespace WebApplication1.Services
{
    public interface IProductService
    {
         Product GetById(int id);
         List<Product> GetAll();
          Product Create(Product product);
        List<Product> GetCategory(string product);
        /*  Product GetByCategory(Category category);*/
    }
}
