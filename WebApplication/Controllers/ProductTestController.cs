/*using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using WebApplication1.Controllers;
using WebApplication1.Model;
using WebApplication1.Repository;
using Xunit;
using Moq;
using WebApplication2.RepositoryMockUP;
using System.Web.Http;
using System.Web.Http.Results;

namespace WebApplication2.Controllers
{
    public class ProductTestController : Controller
    {
        [Fact]
        public void ProductController_Index_ValidLargNumber()
        {
            //arrange
            Mock<IProductRepository> productRepositoryMock = new Mock<IProductRepository>();
            productRepositoryMock.Setup(x => x.GetAll()).Returns(new List<Product>
            {
                 new Product { Id = 1 }, new Product {  Id = 2 }
            });  

             var productController = new ProductController(productRepositoryMock.Object);
            //Act
            var product = productController.GetAll();


            //assert
            Assert.NotNull(product);
            *//*Assert.Equal(product);*//*

        }
        [Fact]
        public void GetReturnsProductWithSameId()
        {
            // Arrange
            Mock<IProductRepository> productRepositoryMock = new Mock<IProductRepository>();
            productRepositoryMock.Setup(x => x.GetById(1))
                .Returns(new Product { Id = 1 });

            var controller = new ProductController(productRepositoryMock.Object);

            // Act
            *//* var actionResult = controller.Get(1);*//*

            IHttpActionResult actionResult = (IHttpActionResult)controller.Get(2);
            var contentResult = actionResult as OkNegotiatedContentResult<Product>;
            // Assert
            Assert. NotNull(actionResult);
            Assert.NotNull(actionResult);
            *//*Assert.Equal(2, actionResult);*//*
        }

        *//*  [Fact]
          public async void Task_GetById_Return_OkResult()
          {
              //Arrange  
              var controller = new ProductController(_productRepository);
              var productId = 2;

              //Act  
              var productById = new List<Product>();
              var products = _productRepository.GetAll();


              //Assert  
              Assert.IsType<OkObjectResult>(products);
          }

          [Fact]
          public async void Task_GetById_Return_NotFoundResult()
          {
              //Arrange  
              var controller = new ProductController(_productRepository);
              var productId = 3;

              //Act  
              var data =   controller.Get(productId);

              //Assert  
              Assert.IsType<NotFoundResult>(data);
          }

          [Fact]
          public async void Task_GetById_Return_BadRequestResult()
          {
              //Arrange  
              var controller = new ProductController(_productRepository);
              int productId = 0;

              //Act  
              var data =   controller.Get(productId);

              //Assert  
              Assert.IsType<BadRequestResult>(data);
          }

          [Fact]
          public async void Task_GetById_MatchResult()
          {
              //Arrange  
              var controller = new  ProductController(_productRepository);
              int productId = 1;

              //Act  
              var data =   controller.Get(productId);

              //Assert  
              Assert.IsType<OkObjectResult>(data);

              var okResult = data.DefaultIfEmpty().BeOfType<OkObjectResult>().Subject;
              var post = okResult.Value.Should().BeAssignableTo<PostViewModel>().Subject;

              Assert.Equal("Test Title 1", post.Title);
              Assert.Equal("Test Description 1", post.Description);
          }*//*



    }
}
*/