using AutoMapper;
using Entity.Interfaces;
using Entity;
using Moq;
using API.Helpers;
using API.Controllers;
using API.Dto;

namespace Social_Network.Test.UserTests
{
    [TestClass]
    public class PostControllerTest
    {
        private IMapper? _mapper;
        private Mock<IGenericRepository<Post>>? _postRepositoryMock;

        [TestInitialize]
        public void Setup()
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            var mapper = mappingConfig.CreateMapper();
            _mapper = mapper;
            _postRepositoryMock = new Mock<IGenericRepository<Post>>();
        }

        [TestMethod]
        public async Task TestShouldCreatePostAsync()
        {
            // Arrange
            PostDto postDto = new()
            {
                PostedMessage = "Det fungerar bra.",
                PostedByUserId = 1,
                PostedToUserId = 2,
                PostedTime = DateTime.Now,
            };

            Post post = new()
            {
                Id = 1,
                PostedMessage = "Det fungerar bra.",
                PostedByUserId = 1,
                PostedToUserId = 2,
                PostedTime = DateTime.Now,
            };

            _postRepositoryMock.Setup(x => x.AddAsync(post))
                .ReturnsAsync(post);

            // Act
            var postController =  new PostController(_postRepositoryMock.Object, _mapper);
            var result = await postController.CreatePostAsync(postDto);

            // Assert
            Assert.AreEqual(result, post);

            //[TestMethod]
            //public async Task TestGetSpecificUserPostsAsync()
            //{
            //    // Arrange
            //    int postedToUserId = 1;
            //    Post post = new()
            //    {
            //        Id = 1,
            //        PostedMessage = "Det fungerar bra.",
            //        PostedByUserId = 1,
            //        PostedToUserId = 2,
            //        PostedTime = DateTime.Now,
            //    },




            //    var allPosts = await _postRepositoryMock

            //    // Act


            //    // Assert


            //}
        }
    }
}
