using Entity;

namespace Infrastructure;

public class NetworkContextSeed
{
    public static async Task SeedAsync(NetworkContext context)
    {
        if (!context.Users.Any())
        {
            var user = new User
            {
                Name = "Steve Jobs",
                Email = "jobs@email.com",
                Password = "apple",
                CreatedTime = DateTime.Now
            };

            var user2 = new User
            {
                Name = "Bill Gates",
                Email = "gates@email.com",
                Password = "windows",
                CreatedTime = DateTime.Now
            };

            await context.Users.AddRangeAsync(user, user2);
            await context.SaveChangesAsync();
        }
    }
}
