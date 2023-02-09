using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Db;
using WebApplication1.Model;
using WebApplication1.Repository;

namespace WebApplication
{
    public class LoginRepositoryTest
    {
        [Fact]
        public void GetUser()
        {
             //Arrange
             var loginUser = new List<LoginRequest>();
            {
                new LoginRequest
                {
                    Name = "ABB",
                    Password = "123",
                };

                var context = new Mock<ProductContext>();
                var dbContext = new Mock <DbSet<LoginRequest>>();

                context.Setup(x => x.Set<LoginRequest>()).Returns(dbContext.Object);
                dbContext.Setup(i => i.AsQueryable()).Returns(loginUser.AsQueryable());

                //Act

                var repository = new LoginRepository(context.Object);
                var getLoginUser = repository.GetAll();
                //Act
                Assert.Equal(loginUser, getLoginUser);
            }
            

        }
        [Fact]
        public void GetAll()
        {
            var users = new List<LoginRequest>()
              {
                  new LoginRequest
                  {
                       Password = "123",
                      Name="Geeta",
                      
                  },
                  new LoginRequest
                  {
                      Password = "23",
                      Name= "eta",

                  },
              };
            var context = new Mock<ProductContext>();
            var dbSetMock = new Mock<DbSet<LoginRequest>>();

            context.Setup(x => x.Set<LoginRequest>()).Returns(dbSetMock.Object);
            dbSetMock.Setup(i => i.AsQueryable()).Returns(users.AsQueryable());
            //Act
            var repository = new LoginRepository(context.Object);
            var getUsers = repository.GetAll();
            Assert.Equal(users, getUsers.ToList());
        }
        [Fact]
        public void GetById()
        {
            //Arrange
            var users =

                  new LoginRequest
                  {
                      
                      Name = "Geeta",
                      Password = "123",
                  };


            var context = new Mock<ProductContext>();
            var dbSetMock = new Mock<DbSet<LoginRequest>>();

            context.Setup(x => x.Set<LoginRequest>()).Returns(dbSetMock.Object);
            dbSetMock.Setup(x => x.Find(It.IsAny<int>())).Returns(users);
            //Act
            var repository = new LoginRepository(context.Object);
            var getUsers = repository.GetById(1);

            //Asset
            Assert.Equal(users, getUsers);


        }
    }
}
