using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Model;
using WebApplication1.Repository;
using WebApplication1.Services;
using WebApplication1.EntityModel;
using AutoMapper;

namespace WebApplication1.Controllers
{
    [Route("Api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
         private readonly IProductService productService;
        private readonly  IMapper mapper;
        public ProductController(IProductService productService, IMapper mapper)
        {
           this.productService = productService;
            this.mapper = mapper;
        }
      /*  [HttpGet]
        public IEnumerable<ProductEntity> GetAll()
        {
            var products = productService.GetAll();
            var productEntity = mapper.Map<List<ProductEntity>>(products);
            return productEntity;
        }
*/

        [HttpGet("{id}")]
        public List<ProductEntity> Get(int id)
        {
            var productById = new List<ProductEntity>();
            var products = productService.GetAll();
            var productsEntity = mapper.Map<List<ProductEntity>>(products);
            foreach (var product in productsEntity)
            {
                if (product.Id == id)
                {
                    productById.Add(product);
                }
            }
            return productById;
        }
        [HttpGet("{getCategoryValue}")]
        public List<ProductEntity> GetByCategory(string product)
        {
            var productById = new List<ProductEntity>();
            var products = productService.GetCategory(product);
            var productsEntity = mapper.Map<List<ProductEntity>>(products);
            foreach (var productcate in productsEntity)
            {
                if (productcate.Category == product.Category)
                {
                    productById.Add(productcate);
                }
            }
            return productsEntity;
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
