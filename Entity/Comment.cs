using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity;
public class Comment : BaseEntity
{
    public Comment()
    {
    }

    public Comment(int postId, int commentedByUserId, string message, DateTime commentedTime)
    {
      PostId = postId;
      CommentedByUserId = commentedByUserId;
      Message = message;
      CommentedTime = commentedTime;
    }

  [ForeignKey("PostId")]
  public int PostId { get; set; }

  public int CommentedByUserId { get; set; }

  public string? Message { get; set; }

  public DateTime CommentedTime { get; set; }
}
