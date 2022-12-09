namespace Entity;

public class Post : BaseEntity
{
  public Post()
  {
  }

  public Post(string postedMessage, int postedByUserId, string postedByUserName, int postedToUserId, DateTime postedTime)
  {
    PostedMessage = postedMessage;
    PostedByUserId = postedByUserId;
    PostedByUserName = postedByUserName;
    PostedToUserId = postedToUserId;
    PostedTime = postedTime;
  }

  public string? PostedMessage { get; set; } = string.Empty;

  [ForeignKey("UserId")]
  public int PostedByUserId { get; set; }

  [ForeignKey("UserName")]
  public string PostedByUserName { get; set; } = string.Empty;

  public int PostedToUserId { get; set; }

  public DateTime PostedTime { get; set; }
}