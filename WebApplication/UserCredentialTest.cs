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
    public class UserCredentialTest
    {
        [Fact]
        public void OnlyOneValueTest()
        {
            //Arrange
            var usercrendial = new List<UserCreadential>()
            {
                new UserCreadential
                {
                    Name="abs",
                    Id=1,
                    Email="kjhdjksd",
                    Password="dd",
                    IsActive=true,
                    CreatedBy=null,
                    UpdatedBy=null,
                    UserId=1,
                }
            };

            var context = new Mock<ProductContext>();
            var dbContext = new Mock<DbSet<UserCreadential>>();

            context.Setup(x => x.Set<UserCreadential>()).Returns(dbContext.Object);
            dbContext.Setup(i => i.AsQueryable()).Returns(usercrendial.AsQueryable());

            //ACT
            var repository = new UserCreadentialRepository(context.Object);
            var getuser = repository.GetAll();

            //Act
            Assert.Equal(usercrendial, getuser);
        }
        [Fact]
        public void GetAll()
        {
            var usercrendial = new List<UserCreadential>()
            {
                new UserCreadential
                {
                    Name="abs",
                    Id=1,
                    Email="kjhdjksd",
                    Password="dd",
                    IsActive=true,
                    CreatedBy=null,
                    UpdatedBy=null,
                    UserId=1,
                }
            };
            var context = new Mock<ProductContext>();
            var dbSetMock = new Mock<DbSet<UserCreadential>>();

            context.Setup(x => x.Set<UserCreadential>()).Returns(dbSetMock.Object);
            dbSetMock.Setup(i => i.AsQueryable()).Returns(usercrendial.AsQueryable());
            //Act
            var repository = new UserCreadentialRepository(context.Object);
            var getUsers = repository.GetAll();
            Assert.Equal(usercrendial, getUsers.ToList());
        }
        [Fact]
        public void GetById()
        {
            //Arrange
            var users =

                   new UserCreadential
                   {
                       Name = "abs",
                       Id = 1,
                       Email = "kjhdjksd",
                       Password = "dd",
                       IsActive = true,
                       CreatedBy = null,
                       UpdatedBy = null,
                       UserId = 1,
                   };


            var context = new Mock<ProductContext>();
            var dbSetMock = new Mock<DbSet<UserCreadential>>();

            context.Setup(x => x.Set<UserCreadential>()).Returns(dbSetMock.Object);
            dbSetMock.Setup(x => x.Find(It.IsAny<int>())).Returns(users);
            //Act
            var repository = new UserCreadentialRepository(context.Object);
            var getUsers = repository.GetById(1);

            //Asset
            Assert.Equal(users, getUsers);


        }
    }
}
