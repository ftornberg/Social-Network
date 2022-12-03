using System.ComponentModel.DataAnnotations.Schema;

namespace Entity;
public class Post : BaseEntity
{

  public Post()
  {
  }

  public Post(string postedMessage, int postedByUserId, int postedToUserId, DateTime postedTime)
  {
    PostedMessage = postedMessage;
    PostedByUserId = postedByUserId;
    PostedToUserId = postedToUserId;
    PostedTime = postedTime;
  }

  public string? PostedMessage { get; set; }

  [ForeignKey("UserId")]
  public int PostedByUserId { get; set; }

  public int PostedToUserId { get; set; }

  // public ICollection<Comment>? Comments { get; set; }

  public DateTime PostedTime { get; set; }
}