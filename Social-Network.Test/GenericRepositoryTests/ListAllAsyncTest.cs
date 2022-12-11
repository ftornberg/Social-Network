using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Social_Network.Test.UserTests;

[TestClass]
public class ListAllAsyncTests
{
    private NetworkContext? _context;

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
    public async Task TestListAllAsync()
    {
        // Arrange
        IReadOnlyList<User>? entities = new List<User>()
                {
                    new User{
                        Id = 1,
                        Name = "Steve Jobs",
                        CreatedTime = DateTime.Now,
                        Email = "jobs@email.com",
                        Password = "apple"
                    },
                    new User{
                        Id = 2,
                        Name = "Bill Gates",
                        CreatedTime = DateTime.Now,
                        Email = "gates@email.com",
                        Password = "windows"
                    },
                    new User{
                        Id = 3,
                        Name = "Mark Zuckerberg",
                        CreatedTime = DateTime.Now,
                        Email = "mark@email.com",
                        Password = "facebook"
                    }
                };
        _context.Set<User>().AddRange(entities);
        await _context.SaveChangesAsync();
        var repository = new GenericRepository<User>(_context);

        // Act
        var result = await repository.ListAllAsync();

        // Assert
        Assert.AreEqual(entities[0], result[0]);
        Assert.AreEqual(entities[1], result[1]);
        Assert.AreEqual(entities[2], result[2]);
    }
}