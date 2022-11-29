namespace Entity;
public class Comment : BaseEntity
{
  public int PostId { get; set; }

  public User PostedBy { get; set; }

  public string? Message { get; set; }

  public DateTime CommentedTime { get; set; }
}
