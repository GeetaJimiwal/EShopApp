using Microsoft.EntityFrameworkCore;
using Moq;
using WebApplication1.Db;
using WebApplication1.Model;
using WebApplication1.Repository;
using Xunit.Sdk;

namespace WebApplication
{
   
    public class UserRepositoryTest
    {
        [Fact]
        public void GetUser()
        {
            //Arrange
            var users = new List<User>()
              {
                  new User
                  {
                      Id = 1,
                      Name="Geeta",
                      Email="Geetabora@Xcdify.com",
                      IsActive=true,
                      CreatedBy=1,
                      UpdatedBy=1,
                  }
              };
            var context = new Mock<ProductContext>();
            var dbSetMock = new Mock<DbSet<User>>();

            context.Setup(x => x.Set<User>()).Returns(dbSetMock.Object);
            dbSetMock.Setup(i => i.AsQueryable()).Returns(users.AsQueryable());
            //Act
            var repository = new UserRepository(context.Object);
            var getUsers = repository.GetAll();

            //Asset
            Assert.Equal(users, getUsers.ToList());

        }

        [Fact]
        public void GetAll()
        {
            var users = new List<User>()
              {
                  new User
                  {
                      Id = 1,
                      Name="Geeta",
                      Email="Geetabora@Xcdify.com",
                      IsActive=true,
                      CreatedBy=1,
                      UpdatedBy=1,
                  },
                    new User
                  {
                      Id = 2,
                      Name="Ram",
                      Email="ram@Xcdify.com",
                      IsActive=true,
                      CreatedBy=1,
                      UpdatedBy=1,
                  },
              };
            var context = new Mock<ProductContext>();
            var dbSetMock = new Mock<DbSet<User>>();

            context.Setup(x => x.Set<User>()).Returns(dbSetMock.Object);
            dbSetMock.Setup(i => i.AsQueryable()).Returns(users.AsQueryable());
            //Act
            var repository = new UserRepository(context.Object);
            var getUsers = repository.GetAll();
            Assert.Equal(users, getUsers.ToList());
        }
        public void GetById()
        {
            //Arrange
            var users =

                  new User
                  {
                      Id = 1,
                      Name = "Geeta",
                      Email = "Geetabora@Xcdify.com",
                      IsActive = true,
                      CreatedBy = 1,
                      UpdatedBy = 1,
                  };
                  
              
            var context = new Mock<ProductContext>();
            var dbSetMock = new Mock<DbSet<User>>();

            context.Setup(x => x.Set<User>()).Returns(dbSetMock.Object);
            dbSetMock.Setup(x => x.Find(It.IsAny<int>())).Returns(users);
            //Act
            var repository = new UserRepository(context.Object);
            var getUsers = repository.GetById(1);

            //Asset
            Assert.Equal(users, getUsers);


        }

    }
}
