namespace Entity;
public partial class Post
{
  public class Comment : Post
  {
    public Guid CommentId { get; set; }

    public Guid CommentUserId { get; set; }

    public string? CommentMessage { get; set; }

    public DateTime CommentedTime { get; set; }
  }
  public static Comment CreateComment(Guid commentUserId, string? commentMessage, DateTime commentedAt)
  {
    return new Comment
    {
      CommentId = Guid.NewGuid(),
      CommentUserId = commentUserId,
      CommentMessage = commentMessage,
      CommentedTime = commentedAt
    };
  }
}