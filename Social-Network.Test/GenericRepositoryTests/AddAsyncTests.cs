using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Social_Network.Test.UserTests;

[TestClass]
public class AddAsyncTests
{
    private NetworkContext? _context;

    [TestInitialize]
    public void SetUp()
    {
        _context = new NetworkContext(new DbContextOptionsBuilder<NetworkContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options);
    }

    [TestCleanup]
    public void TearDown()
    {
        _context.Dispose();
    }

    [TestMethod]
    public async Task TestAddAsync()
    {
        // Arrange
        var entity = new User();
        var repository = new GenericRepository<User>(_context);

        // Act
        var result = await repository.AddAsync(entity);

        // Assert
        Assert.AreEqual(entity, result);
        Assert.AreEqual(1, await _context.Set<User>().CountAsync());
    }
}
