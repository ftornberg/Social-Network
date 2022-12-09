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

      var user3 = new User
      {
        Name = "Mark Zuckerberg",
        Email = "thezuck@fb.com",
        Password = "facebook",
        CreatedTime = DateTime.Now
      };

      var user4 = new User
      {
        Name = "Elon Musk",
        Email = "musky@tesla.com",
        Password = "tesla",
        CreatedTime = DateTime.Now
      };

      var user5 = new User
      {
        Name = "Jeff Bezos",
        Email = "jeff@amazon.com",
        Password = "amazon",
        CreatedTime = DateTime.Now
      };

      await context.Users.AddRangeAsync(user, user2, user3, user4, user5);
      await context.SaveChangesAsync();
    }

    if (!context.Posts.Any())
    {

      var post = new Post
      {
        PostedMessage = "I am Steve Jobs",
        PostedByUserId = 1,
        PostedByUserName = "Steve Jobs",
        PostedToUserId = 1,
        PostedTime = DateTime.Now
      };

      var post2 = new Post
      {
        PostedMessage = "I am Bill Gates",
        PostedByUserId = 2,
        PostedByUserName = "Bill Gates",
        PostedToUserId = 2,
        PostedTime = DateTime.Now
      };

      var post3 = new Post
      {
        PostedMessage = "I am Mark Zuckerberg",
        PostedByUserId = 3,
        PostedByUserName = "Mark Zuckerberg",
        PostedToUserId = 3,
        PostedTime = DateTime.Now
      };

      var post4 = new Post
      {
        PostedMessage = "I am Elon Musk",
        PostedByUserId = 4,
        PostedByUserName = "Elon Musk",
        PostedToUserId = 4,
        PostedTime = DateTime.Now
      };

      var post5 = new Post
      {
        PostedMessage = "I am Jeff Bezos",
        PostedByUserId = 5,
        PostedByUserName = "Jeff Bezos",
        PostedToUserId = 5,
        PostedTime = DateTime.Now
      };

      var post6 = new Post
      {
        PostedMessage = "I am Steve Jobs",
        PostedByUserId = 1,
        PostedByUserName = "Steve Jobs",
        PostedToUserId = 2,
        PostedTime = DateTime.Now
      };

      var post7 = new Post
      {
        PostedMessage = "I am Bill Gates",
        PostedByUserId = 2,
        PostedByUserName = "Bill Gates",
        PostedToUserId = 3,
        PostedTime = DateTime.Now
      };

      var post8 = new Post
      {
        PostedMessage = "I am Mark Zuckerberg",
        PostedByUserId = 3,
        PostedByUserName = "Mark Zuckerberg",
        PostedToUserId = 4,
        PostedTime = DateTime.Now
      };

      var post9 = new Post
      {
        PostedMessage = "I am Elon Musk",
        PostedByUserId = 4,
        PostedByUserName = "Elon Musk",
        PostedToUserId = 5,
        PostedTime = DateTime.Now
      };

      var post10 = new Post
      {
        PostedMessage = "I am Jeff Bezos",
        PostedByUserId = 5,
        PostedByUserName = "Jeff Bezos",
        PostedToUserId = 1,
        PostedTime = DateTime.Now
      };

      await context.Posts.AddRangeAsync(post, post2, post3, post4, post5, post6, post7, post8, post9, post10);
      await context.SaveChangesAsync();
    }

    if (!context.Followers.Any())
    {
      var follower = new Follower
      {
        FollowerUserId = 1,
        FollowsUserId = 2,
      };

      var follower2 = new Follower
      {
        FollowerUserId = 1,
        FollowsUserId = 3,
      };

      var follower3 = new Follower
      {
        FollowerUserId = 1,
        FollowsUserId = 4,
      };

      var follower4 = new Follower
      {
        FollowerUserId = 2,
        FollowsUserId = 1,
      };

      var follower5 = new Follower
      {
        FollowerUserId = 2,
        FollowsUserId = 3,
      };
      await context.Followers.AddRangeAsync(follower, follower2, follower3, follower4, follower5);
      await context.SaveChangesAsync();
    }
  }
}
