using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Moq;
using WebApplication1;
using WebApplication1.Db;
using WebApplication1.Model;
using WebApplication1.Repository;
 
using Xunit.Sdk;


namespace WebApplication
{
    public class ProductRepositoryTest
    {
        [Fact]

        public void GetProductWhereIsOnlyOneValueExitsTest()
        {
            // Arrange
            var products = new List<Product>()
            {
                new Product
                {
                    Id= 1,
                    Category="T-shirt",
                    Name= "Test1",
                    Image="sss",
                    Price=1,
                    Quantity=1,
                }
            };
            var context = new Mock<ProductContext>();
            var dbSetMock = new Mock<DbSet<Product>>();

            context.Setup(x => x.Set<Product>()).Returns(dbSetMock.Object);
            dbSetMock.Setup(i => i.AsQueryable()).Returns(products.AsQueryable());

            // Act
            var repository = new ProductRepository(context.Object);
            var getproduct = repository.GetAll();

            // Assert
            Assert.Equal(1, getproduct.Count);
        }

        [Fact]
        public void GetAllProductTest()
        {
            // Arrange
            var products = new List<Product>()
            {
                new Product
                {
                   Id= 1,
                    Category="T-shirt",
                    Name= "Test1",
                    Image="sss",
                    Price=1,
                    Quantity=1,
                },
                new Product
                {
                   Id= 2,
                    Category="T-shirt",
                    Name= "Test3",
                    Image="sss",
                    Price=1,
                    Quantity=1,
                }
            };
            var context = new Mock<ProductContext>();
            var dbSetMock = new Mock<DbSet<Product>>();

            context.Setup(x => x.Set<Product>()).Returns(dbSetMock.Object);
            dbSetMock.Setup(i => i.AsQueryable()).Returns(products.AsQueryable());

            // Act
            var repository = new ProductRepository(context.Object);
            var getProucts = repository.GetAll();

            // Assert
            Assert.Equal(products, getProucts.ToList());
        }

        [Fact]
        public void GetProductByIdTest()
        {
            // Arrange
            var product =
                new Product
                {
                    Id = 1,
                    Category = "T-shirt",
                    Name = "Test1",
                    Image = "sss",
                    Price = 1,
                    Quantity = 1,
                };

            var context = new Mock<ProductContext>();
            var dbSetMock = new Mock<DbSet<Product>>();

            context.Setup(x => x.Set<Product>()).Returns(dbSetMock.Object);
            dbSetMock.Setup(x => x.Find(It.IsAny<int>())).Returns(product);
            // Act
            var repository = new ProductRepository(context.Object);
            var gateproduct = repository.GetById(1);

            // Assert
            Assert.Equal(product, gateproduct);
        }
    }
        
   }
 
