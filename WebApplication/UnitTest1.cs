/*using Microsoft.Identity.Client;
using WebApplication1.Repository;
using WebApplication1.Model;
using WebApplication1.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication
{
    public class UnitTest1
    {
        private readonly IProductRepository productRepository;
        public UnitTest1(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
    
        [Fact]
        public void Test1_GetById()
        {
            //Assert
            var controller = new ProductController(productRepository);
            var productId = 1;
          
            //Act
            var data = controller.Get(productId);
            //Assert
            Assert.IsType<OkObjectResult>(data);
        }
    }
}*/