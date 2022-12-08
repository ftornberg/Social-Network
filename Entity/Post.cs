using System.ComponentModel.DataAnnotations.Schema;

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

  public string? PostedMessage { get; set; }

  [ForeignKey("UserId")]
  public int PostedByUserId { get; set; }

  [ForeignKey("UserName")]
  public string PostedByUserName { get; set; }

  public int PostedToUserId { get; set; }

  public DateTime PostedTime { get; set; }
}