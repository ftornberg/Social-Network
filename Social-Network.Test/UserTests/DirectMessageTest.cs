namespace Social_Network.Test.UserTests;

[TestClass]
public class DirectMessageTest
{
    private IMapper? _mapper;
    private Mock<IGenericRepository<DirectMessage>>? _directMessageRepositoryMock;
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
        _directMessageRepositoryMock = new Mock<IGenericRepository<DirectMessage>>();
        _userRepositoryMock = new Mock<IGenericRepository<User>>();

        _directMessageRepositoryMock?.Setup(x => x.ListAllAsync())
            .ReturnsAsync(new List<DirectMessage>
            {
                    new DirectMessage(
                        1,
                        "Max",
                        2,
                        "Isac",
                        "HelloUser2FromUser1",
                        DateTime.Now
                    ),
                    new DirectMessage (
                        2,
                        "Isac",
                        1,
                        "Max",
                        "HelloUser1FromUser2",
                        DateTime.Now
                    ),
                    new DirectMessage (
                        3,
                        "Tobias",
                        1,
                        "Max",
                        "HelloUser1FromUser3",
                        DateTime.Now
                    )
        });
    }

    [TestMethod]
    public async Task TestShouldGetMessagesFromTwoSpecificUsersFromController()
    {
        // Act
        var direktMessageController = new DirectMessageController(_directMessageRepositoryMock.Object, _mapper, _userRepositoryMock.Object);
        var direktMessageDto = await direktMessageController.GetMessagesAsync(1, 2);

        // Assert
        Assert.AreEqual("HelloUser1FromUser2", direktMessageDto.Value[0].Message);
        Assert.AreEqual("HelloUser2FromUser1", direktMessageDto.Value[1].Message);
    }

    [TestMethod]
    public async Task TestShouldGetMessagesFromSpecificUserIdFromController()
    {
        // Act
        var direktMessageController = new DirectMessageController(_directMessageRepositoryMock.Object, _mapper, _userRepositoryMock.Object);
        var direktMessageDto = await direktMessageController.GetMessagesAsync(1, 2);

        // Assert
        Assert.AreEqual(2, direktMessageDto.Value.Count);
    }

    [TestMethod]
    public async Task TestShouldGetSpecificUsersMessageFromController()
    {
        // Act
        var direktMessageController = new DirectMessageController(_directMessageRepositoryMock.Object, _mapper, _userRepositoryMock.Object);
        var direktMessageDto = await direktMessageController.GetMessagesAsync(1, 2);

        var containsOnlyCorrectUserIds = true;
        foreach (var item in direktMessageDto.Value)
        {
            if (item.SenderUserId != 1 && item.SenderUserId != 2)
                containsOnlyCorrectUserIds = false;
        }

        // Assert
        Assert.IsTrue(containsOnlyCorrectUserIds);
    }
}
