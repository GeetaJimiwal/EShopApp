using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Model;
using WebApplication1.Repository;

namespace WebApplication1.Controllers
{
    [Route("Api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        [HttpGet]
        public IEnumerable<Product> GetAll()
        {
      
             var products = _productRepository.GetAll();
            return products;
        }
        [HttpGet("{id}")]
        public List<Product> Get(int id)
        {
            var productById = new List<Product>();
            var products = _productRepository.GetAll();
            foreach (var product in products)
            {
                if (product.Id == id)
                {
                    productById.Add(product);
                }
            }
            return productById;
        }
        [HttpPost]
        public void Post([FromBody] string value)
        {

        }
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {

        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }

        
    }
}
