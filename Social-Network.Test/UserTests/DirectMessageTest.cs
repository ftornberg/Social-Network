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
    }

    [TestMethod]
    public async Task TestShouldGetMessagesFromControllerAsync()
    {
        _directMessageRepositoryMock?.Setup(x => x.ListAllAsync())
            .ReturnsAsync(new List<DirectMessage>
            {
                    new DirectMessage(
                        1,
                        2,
                        "Hello",
                        DateTime.Now
                    ),
                    new DirectMessage (
                        2,
                        1,
                        "Hello2",
                        DateTime.Now
                    ),
                    new DirectMessage (
                        3,
                        1,
                        "Hello again",
                        DateTime.Now
                    )
            });

        // Act
        var direktMessageController = new DirectMessageController(_directMessageRepositoryMock.Object, _mapper, _userRepositoryMock.Object);
        var direktMessageDto = await direktMessageController.GetMessagesAsync(1, 2);

        var containsOnlyCorrectUserIds = true;
        foreach (var item in direktMessageDto.Value)
        {
            if (item.Sender != 1 && item.Sender != 2)
                containsOnlyCorrectUserIds = false;
        }

        // Assert
        Assert.AreEqual("Hello2", direktMessageDto.Value[0].Message);
        Assert.AreNotEqual("Hello again", direktMessageDto.Value[1].Message);
        Assert.AreEqual("Hello", direktMessageDto.Value[1].Message);
        Assert.AreEqual(2, direktMessageDto.Value.Count);
        Assert.IsTrue(containsOnlyCorrectUserIds);
    }
}
