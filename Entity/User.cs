namespace Entity;

public class User
{
  public int Id { get; set; }

  public string? Name { get; set; }

  public string? Email { get; set; }

  public string? Password { get; set; }

  public List<User>? Followers { get; set; }

  public List<Post>? Posts { get; set; }

  public List<DirectMessage>? Messages { get; set; }

  public DateTime CreatedTime { get; set; }
}