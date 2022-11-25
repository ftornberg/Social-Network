namespace Entity;
public class Post
{
  public int Id { get; set; }

  public int UserId { get; set; }

  public string? PostedMessage { get; set; }

  public List<Comment>? Comments { get; set; }

  public DateTime PostedTime { get; set; }
  public object User { get; set; }
}