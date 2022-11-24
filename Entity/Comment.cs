namespace Entity;
public class Comment
{
  public int Id { get; set; }

  public int PostId { get; set; }

  public User PostedBy { get; set; }

  public string? Message { get; set; }

  public DateTime CommentedTime { get; set; }
}
