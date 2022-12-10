using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Social_Network.Test.UserTests;

[TestClass]
public class GetByIdAsyncTests
{
    private NetworkContext _context;

    [TestInitialize]
    public void TestInitialize()
    {
        _context = new NetworkContext(new DbContextOptionsBuilder<NetworkContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options);
    }

    [TestCleanup]
    public void TestCleanup()
    {
        _context.Dispose();
    }

    [TestMethod]
    public async Task TestGetByIdAsync()
    {
        // Arrange
        var entity = new User() { Id = 1 };
        _context.Set<User>().Add(entity);
        await _context.SaveChangesAsync();
        var repository = new GenericRepository<User>(_context);

        // Act
        var result = await repository.GetByIdAsync(1);

        // Assert
        Assert.AreEqual(entity, result);
    }
}