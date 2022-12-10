namespace Social_Network.Test.UserTests;

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

            _userRepositoryMock?.Setup(x => x.ListAllAsync())
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
    }

    [TestMethod]
    public async Task TestShouldGetUserByIdFromController()
    {
        // Arrange
        _userRepositoryMock?.Setup(x => x.GetByIdAsync(1))
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
        var userDto = await userController.GetUserByIdAsync(1);

        // Assert
        Assert.AreEqual(1, userDto.Value.Id);
        Assert.AreEqual("max@email.com", userDto.Value.Email);
        Assert.AreNotEqual(2, userDto.Value.Id);
    }

    [TestMethod]
    public async Task TestShouldGetSpecificUserNameFromController()
    {
        // Act
        var userController = new UserController(_userRepositoryMock.Object, _mapper);
        var users = await userController.GetUsersAsync();

        // Assert
        Assert.AreEqual("Max", users.Value[0].Name);
        Assert.AreEqual("Isac", users.Value[1].Name);
    }

    [TestMethod]
    public async Task TestShouldGetAllUsersFromController()
    {
        // Act
        var userController = new UserController(_userRepositoryMock.Object, _mapper);
        var users = await userController.GetUsersAsync();

        // Assert
        Assert.AreEqual(2, users.Value.Count);
    }
}
