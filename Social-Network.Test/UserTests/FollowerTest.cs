using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Controllers;
using API.Helpers;
using AutoMapper;
using Entity;
using Entity.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Social_Network.Test.UserTests
{
    [TestClass]
    public class FollowerTest
    {
        private IMapper? _mapper;
        private Mock<IGenericRepository<Follower>>? _followerRepositoryMock;
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
            _followerRepositoryMock = new Mock<IGenericRepository<Follower>>();
            _userRepositoryMock = new Mock<IGenericRepository<User>>();
        }
        
        [TestMethod]
        public async Task TestShouldGetFollowersForUserFromController()
        {
            // Arrange
            _followerRepositoryMock?.Setup(x => x.ListAllAsync())
            .ReturnsAsync(new List<Follower>
            {
                new Follower
                {
                    FollowerUserId = 1,
                    FollowsUserId = 2,
                },
                new Follower
                {
                    FollowerUserId = 3,
                    FollowsUserId = 2,
                },
                new Follower
                {
                    FollowerUserId = 4,
                    FollowsUserId = 1,
                }
            });

            // Act
            var followerController = new FollowerController(_followerRepositoryMock.Object,_userRepositoryMock.Object,_mapper);
            var followerDto = await followerController.GetFollowersForUserAsync(2);

            var containsOnlyCorrectUserId = true;
            foreach (var item in followerDto.Value)
            {
                if(item.FollowsUserId != 2)
                    containsOnlyCorrectUserId = false;
            }

            // Assert
            Assert.AreNotEqual(3, followerDto.Value.Count);
            Assert.AreEqual(2, followerDto.Value.Count);
            Assert.IsTrue(containsOnlyCorrectUserId);
        }
    }
}