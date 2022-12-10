namespace Social_Network.Test.UserTests;

[TestClass]
public class PostControllerTest
{
    private IMapper? _mapper;
    private Mock<IGenericRepository<Post>>? _postRepositoryMock;
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
        _postRepositoryMock = new Mock<IGenericRepository<Post>>();
        _followerRepositoryMock = new Mock<IGenericRepository<Follower>>();
        _userRepositoryMock = new Mock<IGenericRepository<User>>();

        _followerRepositoryMock?.Setup(x => x.ListAllAsync())
        .ReturnsAsync(new List<Follower>
        {
                new Follower
                (
                    2,
                    1
                )
        }
        );
        _postRepositoryMock?.Setup(x => x.ListAllAsync())
            .ReturnsAsync(new List<Post>
            {
                    new Post{
                        Id = 1,
                        PostedMessage = "Hej",
                        PostedByUserId = 1,
                        PostedToUserId = 2,
                        PostedTime = DateTime.Now
                    },
                    new Post {
                        Id = 2,
                        PostedMessage = "Hello",
                        PostedByUserId = 1,
                        PostedToUserId = 3,
                        PostedTime = DateTime.Now
                    },
                    new Post {
                        Id = 3,
                        PostedMessage = "Hello2",
                        PostedByUserId = 1,
                        PostedToUserId = 2,
                        PostedTime = DateTime.Now
                    },
                    new Post {
                        Id = 4,
                        PostedMessage = "Hello Kitty",
                        PostedByUserId = 3,
                        PostedToUserId = 2,
                        PostedTime = DateTime.Now
                    }
            });
    }

    [TestMethod]
    public async Task TestShouldGetPostsPostedToSpecificUserFromController()
    {
        var userIdToTest = 2;

        // Act 1
        var postController = new PostController(_postRepositoryMock.Object, _mapper, _followerRepositoryMock.Object, _userRepositoryMock.Object);
        var postDto = await postController.GetPostsToSpecificUserAsync(userIdToTest);

        // Assert 1
        Assert.AreEqual("Hello2", postDto.Value[1].PostedMessage);
        Assert.AreNotEqual("Hello", postDto.Value[2].PostedMessage);
        Assert.AreEqual("Hej", postDto.Value[2].PostedMessage);
    }

    [TestMethod]
    public async Task TestShouldGetPostsPostedWithUserIdFromController()
    {
        var userIdToTest = 2;

        // Act 1
        var postController = new PostController(_postRepositoryMock.Object, _mapper, _followerRepositoryMock.Object, _userRepositoryMock.Object);
        var postDto = await postController.GetPostsToSpecificUserAsync(userIdToTest);

        var containsOnlyCorrectUserId = true;
        foreach (var item in postDto.Value)
        {
            if (item.PostedToUserId != userIdToTest)
                containsOnlyCorrectUserId = false;
        }

        // Assert 1
        Assert.AreEqual(3, postDto.Value.Count);
        Assert.IsTrue(containsOnlyCorrectUserId);
    }

    [TestMethod]
    public async Task TestShouldGetAllPostsFromController()
    {
        

        // Act 1
        var postController = new PostController(_postRepositoryMock.Object, _mapper, _followerRepositoryMock.Object, _userRepositoryMock.Object);
        var postDto = await postController.GetAllPostsAsync(2);

        // Assert 1
        Assert.AreEqual(3, postDto.Value.Count);
    }

    [TestMethod]
    public async Task TestShouldGetAllPostsSortedByDescendingFromController()
    {
        

        // Act 1
        var postController = new PostController(_postRepositoryMock.Object, _mapper, _followerRepositoryMock.Object, _userRepositoryMock.Object);
        var postDto = await postController.GetAllPostsAsync(2);

        // Assert 1
        Assert.AreEqual("Hello2", postDto.Value[0].PostedMessage);
        Assert.AreEqual("Hello", postDto.Value[1].PostedMessage);
        Assert.AreEqual("Hej", postDto.Value[2].PostedMessage);

    }
}
