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
        FollowerUserName = "Steve Jobs",
        FollowsUserId = 2,
        FollowsUserName = "Bill Gates"
      };

      var follower2 = new Follower
      {
        FollowerUserId = 1,
        FollowerUserName = "Steve Jobs",
        FollowsUserId = 3,
        FollowsUserName = "Mark Zuckerberg"
      };

      var follower3 = new Follower
      {
        FollowerUserId = 1,
        FollowerUserName = "Steve Jobs",
        FollowsUserId = 4,
        FollowsUserName = "Elon Musk"
      };

      var follower4 = new Follower
      {
        FollowerUserId = 2,
        FollowerUserName = "Bill Gates",
        FollowsUserId = 1,
        FollowsUserName = "Steve Jobs"
      };

      var follower5 = new Follower
      {
        FollowerUserId = 2,
        FollowerUserName = "Bill Gates",
        FollowsUserId = 3,
        FollowsUserName = "Mark Zuckerberg"
      };
      await context.Followers.AddRangeAsync(follower, follower2, follower3, follower4, follower5);
      await context.SaveChangesAsync();
    }

    if (!context.DirectMessages.Any())
    {
      var dm = new DirectMessage
      {
        Message = "Hello Bill",
        SenderUserId = 1,
        SenderUserName = "Steve Jobs",
        ReceiverUserId = 2,
        ReceiverUserName = "Bill Gates",
        TimeSent = DateTime.Now
      };

      var dm2 = new DirectMessage
      {
        Message = "Hello Steve",
        SenderUserId = 2,
        SenderUserName = "Bill Gates",
        ReceiverUserId = 1,
        ReceiverUserName = "Steve Jobs",
        TimeSent = DateTime.Now
      };

      var dm3 = new DirectMessage
      {
        Message = "Hello Mark",
        SenderUserId = 1,
        SenderUserName = "Steve Jobs",
        ReceiverUserId = 3,
        ReceiverUserName = "Mark Zuckerberg",
        TimeSent = DateTime.Now
      };

      var dm4 = new DirectMessage
      {
        Message = "Hello Steve",
        SenderUserId = 3,
        SenderUserName = "Mark Zuckerberg",
        ReceiverUserId = 1,
        ReceiverUserName = "Steve Jobs",
        TimeSent = DateTime.Now
      };

      var dm5 = new DirectMessage
      {
        Message = "Hello Elon",
        SenderUserId = 1,
        SenderUserName = "Steve Jobs",
        ReceiverUserId = 4,
        ReceiverUserName = "Elon Musk",
        TimeSent = DateTime.Now
      };

      var dm6 = new DirectMessage
      {
        Message = "Hello Steve",
        SenderUserId = 4,
        SenderUserName = "Elon Musk",
        ReceiverUserId = 1,
        ReceiverUserName = "Steve Jobs",
        TimeSent = DateTime.Now
      };

      var dm7 = new DirectMessage
      {
        Message = "Hello Jeff",
        SenderUserId = 1,
        SenderUserName = "Steve Jobs",
        ReceiverUserId = 5,
        ReceiverUserName = "Jeff Bezos",
        TimeSent = DateTime.Now
      };

      var dm8 = new DirectMessage
      {
        Message = "Hello Steve",
        SenderUserId = 5,
        SenderUserName = "Jeff Bezos",
        ReceiverUserId = 1,
        ReceiverUserName = "Steve Jobs",
        TimeSent = DateTime.Now
      };

      var dm9 = new DirectMessage
      {
        Message = "Hello Steve",
        SenderUserId = 2,
        SenderUserName = "Bill Gates",
        ReceiverUserId = 3,
        ReceiverUserName = "Mark Zuckerberg",
        TimeSent = DateTime.Now
      };

      var dm10 = new DirectMessage
      {
        Message = "Hello Bill",
        SenderUserId = 3,
        SenderUserName = "Mark Zuckerberg",
        ReceiverUserId = 2,
        ReceiverUserName = "Bill Gates",
        TimeSent = DateTime.Now
      };

      var dm11 = new DirectMessage
      {
        Message = "Hello Bill",
        SenderUserId = 2,
        SenderUserName = "Bill Gates",
        ReceiverUserId = 4,
        ReceiverUserName = "Elon Musk",
        TimeSent = DateTime.Now
      };

      var dm12 = new DirectMessage
      {
        Message = "Hello Bill",
        SenderUserId = 4,
        SenderUserName = "Elon Musk",
        ReceiverUserId = 2,
        ReceiverUserName = "Bill Gates",
        TimeSent = DateTime.Now
      };

      var dm13 = new DirectMessage
      {
        Message = "Hello Bill",
        SenderUserId = 2,
        SenderUserName = "Bill Gates",
        ReceiverUserId = 5,
        ReceiverUserName = "Jeff Bezos",
        TimeSent = DateTime.Now
      };

      var dm14 = new DirectMessage
      {
        Message = "Hello Bill",
        SenderUserId = 5,
        SenderUserName = "Jeff Bezos",
        ReceiverUserId = 2,
        ReceiverUserName = "Bill Gates",
        TimeSent = DateTime.Now
      };

      var dm15 = new DirectMessage
      {
        Message = "Hello Mark",
        SenderUserId = 3,
        SenderUserName = "Mark Zuckerberg",
        ReceiverUserId = 4,
        ReceiverUserName = "Elon Musk",
        TimeSent = DateTime.Now
      };

      var dm16 = new DirectMessage
      {
        Message = "Hello Mark",
        SenderUserId = 4,
        SenderUserName = "Elon Musk",
        ReceiverUserId = 3,
        ReceiverUserName = "Mark Zuckerberg",
        TimeSent = DateTime.Now
      };

      var dm17 = new DirectMessage
      {
        Message = "Hello Mark",
        SenderUserId = 3,
        SenderUserName = "Mark Zuckerberg",
        ReceiverUserId = 5,
        ReceiverUserName = "Jeff Bezos",
        TimeSent = DateTime.Now
      };

      var dm18 = new DirectMessage
      {
        Message = "Hello Mark",
        SenderUserId = 5,
        SenderUserName = "Jeff Bezos",
        ReceiverUserId = 3,
        ReceiverUserName = "Mark Zuckerberg",
        TimeSent = DateTime.Now
      };

      var dm19 = new DirectMessage
      {
        Message = "Hello Elon",
        SenderUserId = 4,
        SenderUserName = "Elon Musk",
        ReceiverUserId = 5,
        ReceiverUserName = "Jeff Bezos",
        TimeSent = DateTime.Now
      };

      var dm20 = new DirectMessage
      {
        Message = "Hello Elon",
        SenderUserId = 5,
        SenderUserName = "Jeff Bezos",
        ReceiverUserId = 4,
        ReceiverUserName = "Elon Musk",
        TimeSent = DateTime.Now
      };

      await context.DirectMessages.AddRangeAsync(dm, dm2, dm3, dm4, dm5, dm6, dm7, dm8, dm9, dm10, dm11, dm12, dm13, dm14, dm15, dm16, dm17, dm18, dm19, dm20);
      await context.SaveChangesAsync();

    }
  }
}
