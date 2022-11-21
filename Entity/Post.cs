namespace Entity;
public partial class Post
{
  public Guid PostId { get; set; }

  public Guid PostUserId { get; set; }

  public string? PostedMessage { get; set; }

  public DateTime PostedTime { get; set; }

  public static Post CreatePost(Guid postUserId, string? postedMessage, DateTime postedAt)
  {
    return new Post
    {
      PostId = Guid.NewGuid(),
      PostUserId = postUserId,
      PostedMessage = postedMessage,
      PostedTime = postedAt
    };
  }


}