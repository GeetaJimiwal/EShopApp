using Microsoft.AspNetCore.Mvc;
using System;
using ECOMMERCEAPP.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
 
 

namespace ECOMMERCEAPP.Controllers
{

    [Route("Api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProductRepository productRepository;
        public   ProductController (IProductRepository _productRepository)
        {
            this.productRepository = _productRepository;
        }
        [HttpGet]
        public IEnumerable<Model.Product> Get()
        {
            var products = productRepository.GetAll();
            return products;
        }
        [HttpGet("id")]
        public Model.Product Get(int id)
        {
            var product = productRepository.GetById(id);
            return product;
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
