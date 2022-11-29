namespace Entity;

public class User : BaseEntity
{

  public User()
  {

  }

  public User(int userId)
  {
    UserId = userId;
    Followers = new List<User>();
    Posts = new List<Post>();
  }

  public int UserId { get; set; }

  public string Name { get; set; }

  public string Email { get; set; }

  public string Password { get; set; }

  public ICollection<User> Followers { get; set; }

  public ICollection<Post> Posts { get; set; }

  public ICollection<Conversation> Messages { get; set; }

  public DateTime CreatedTime { get; set; }
}