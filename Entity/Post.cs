namespace Entity;
public class Post : BaseEntity
{

  public int UserId { get; set; }

  public string? PostedMessage { get; set; }

  public List<Comment>? Comments { get; set; }

  public DateTime PostedTime { get; set; }
}