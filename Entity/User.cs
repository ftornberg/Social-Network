namespace Entity;
using System.ComponentModel.DataAnnotations.Schema;

public class User : BaseEntity
{

  public User()
  {
  }

  public User(string name, string email, string password, DateTime createdTime)
  {
    Name = name;
    Email = email;
    Password = password;
    CreatedTime = createdTime;
    // Followers = new List<User>();
    // Posts = new List<Post>();
    // Messages = new List<Conversation>();
  }

  public string Name { get; set; }
  
  public string Email { get; set; }

  public string Password { get; set; }

  // public ICollection<User> Followers { get; set; }

  // public ICollection<Post> Posts { get; set; }

  // public ICollection<Conversation> Messages { get; set; }

  public DateTime CreatedTime { get; set; }
}