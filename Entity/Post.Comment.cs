namespace Entity;
public partial class Post
{
  public class Comment : Post
  {
    public Comment(int userId, int postId) : base(userId, postId)

    {
      UserId = userId;
      PostId = postId;
    }
    public int Id { get; set; }

    public int PostId { get; set; }

    public int UserId { get; set; }

    public string? Message { get; set; }

    public DateTime CommentedTime { get; set; }
  }
}