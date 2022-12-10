namespace Social_Network.Test.UserTests;

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
    }

    [TestMethod]
    public async Task TestShouldGetFollowersForUserFromController()
    {
        // Act
        var followerController = new FollowerController(_followerRepositoryMock.Object, _userRepositoryMock.Object, _mapper);
        var followerDto = await followerController.GetSpecificUserFollowersAsync(2);

        // Assert
        Assert.AreNotEqual(3, followerDto.Value.Count);
        Assert.AreEqual(2, followerDto.Value.Count);
    }

    [TestMethod]
    public async Task TestShouldGetFollowersWithUserIdFromController()
    {
        var followerController = new FollowerController(_followerRepositoryMock.Object, _userRepositoryMock.Object, _mapper);
        var followerDto = await followerController.GetSpecificUserFollowersAsync(2);

        var containsOnlyCorrectUserId = true;
        foreach (var item in followerDto.Value)
        {
            if (item.FollowsUserId != 2)
                containsOnlyCorrectUserId = false;
        }

        Assert.IsTrue(containsOnlyCorrectUserId);    }
}
