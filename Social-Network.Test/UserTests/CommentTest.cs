using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Controllers;
using API.Dto;
using API.Helpers;
using AutoMapper;
using Entity;
using Entity.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;


namespace Social_Network.Test.UserTests
{
    [TestClass]
    public class CommentControllerTest
    {
        private IMapper _mapper;
        private Mock<IGenericRepository<Comment>> _commentRepositoryMock;

        [TestInitialize]
        public void Setup()
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            var mapper = mappingConfig.CreateMapper();
            _mapper = mapper;
            _commentRepositoryMock = new Mock<IGenericRepository<Comment>>();

        }
        [TestMethod]

        public async Task TestShouldGetCommentByIdFromController()
        {
            // Arrange
            _commentRepositoryMock.Setup(x => x.GetByIdAsync(1))
                .ReturnsAsync(new Comment
                {
                    Id = 1,
                    PostId = 1,
                    CommentedByUserId = 2,
                    Message = "Galaxy",
                    CommentedTime = DateTime.Now,
                });

            // Act
            var commentController = new CommentController(_commentRepositoryMock.Object, _mapper);
            var commentDto = await commentController.GetCommentById(1);

            // Assert
            Assert.AreEqual(1, commentDto.Value.PostId);
            Assert.AreNotEqual(2, commentDto.Value.PostId);
        }

        [TestMethod]

        public async Task TestShouldGetCommentsByListFromController()
        {
            // Arrange
            _commentRepositoryMock.Setup(x => x.ListAllAsync())
            .ReturnsAsync(new List<Comment>
            {
                new Comment
                {
                    Id = 1,
                    PostId = 1,
                    CommentedByUserId = 2,
                    Message = "Dart Vader",
                    CommentedTime = DateTime.Now,
                },
                new Comment
                {
                    Id = 2,
                    PostId = 1,
                    CommentedByUserId = 2,
                    Message = "Gandalf",
                    CommentedTime = DateTime.Now,
                }
            });

            // Act
            var commentController = new CommentController(_commentRepositoryMock.Object, _mapper);
            var comments = await commentController.GetComments();
            // Assert
            Assert.AreEqual(2, comments.Count);
        }
    }
}