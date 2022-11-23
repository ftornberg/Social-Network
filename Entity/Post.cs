namespace Entity;
public partial class Post : User
{
  public Post(int userId, int postId) : base(userId)
  {
    UserId = userId;
    Id = postId;
  }
  public int Id { get; set; }

  public int UserId { get; set; }

  public string? PostedMessage { get; set; }

  public List<Comment>? Comments { get; set; }

  public DateTime PostedTime { get; set; }
}