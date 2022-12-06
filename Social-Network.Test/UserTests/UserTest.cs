using AutoMapper;
using Entity;
using Entity.Interfaces;
using API.Dto;
using API.Helpers;
using API.Controllers;
using Moq;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace Social_Network.Test.UserTests
{
    [TestClass]
    public class UserControllerTest
    {
        private IMapper? _mapper;
        private Mock<IGenericRepository<User>>? _userRepositoryMock;

        [TestInitialize]
        public void Setup()
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            var mapper = mappingConfig.CreateMapper();
            _mapper = mapper;
            _userRepositoryMock = new Mock<IGenericRepository<User>>();

        }
        [TestMethod]
        public async Task TestShouldGetUserByIdFromControllerAsync()
        {
            // Arrange
            _userRepositoryMock.Setup(x => x.GetByIdAsync(1))
                .ReturnsAsync(new User
                {
                    Id = 1,
                    Name = "Max",
                    Email = "max@email.com",
                    Password = "password",
                    CreatedTime = DateTime.Now,
                });

            // Act
            var userController = new UserController(_userRepositoryMock.Object, _mapper);
            var userDto = await userController.GetInfoAboutUserAsync(1);
            
            // Assert
            Assert.AreEqual(1, userDto.Value.Id);
            Assert.AreNotEqual(2, userDto.Value.Id);
        }
        
        [TestMethod]
        public async Task TestShouldGetAllUsersAsync()
        {
            // Arrange
            _userRepositoryMock.Setup(x => x.ListAllAsync())
                .ReturnsAsync(new List<User>
                {
                    new User
                    {
                        Id = 1,
                        Name = "Max",
                        Email = "max@email.com",
                        Password = "password",
                        CreatedTime = DateTime.Now,
                    },
                    new User
                    {
                        Id = 2,
                        Name = "Isac",
                        Email = "isac@email.com",
                        Password = "password",
                        CreatedTime = DateTime.Now,
                    }
                });

            // Act
            var userController = new UserController(_userRepositoryMock.Object, _mapper);
            var users = await userController.GetUsersAsync();

            // Assert
            Assert.IsNull(users.Value); // Varför kommer vi inte åt users.Result.Value?
        }
    }
}