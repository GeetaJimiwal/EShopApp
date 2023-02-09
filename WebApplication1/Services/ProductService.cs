using WebApplication1.Model;
using WebApplication1.Repository;


namespace WebApplication1.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public Product Create(Product product)
        {
             
            product.Category = "tshirt";
            product.Quantity = 1;
            product= _repository.Create(product);
            return product;
        }

        public List<Product> GetAll()
        { 
            var products = _repository.GetAll();
            return products;
        }

        public Product GetById(int id)
        {
            var product = _repository.GetById(id);
            return product;
        }
    }
}
