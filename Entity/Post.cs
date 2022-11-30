namespace Entity;
public class Post : BaseEntity
{
  public string? PostedMessage { get; set; }

  public ICollection<Comment>? Comments { get; set; }

  public DateTime PostedTime { get; set; }
}