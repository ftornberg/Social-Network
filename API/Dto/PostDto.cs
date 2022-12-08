using Entity;
namespace API.Dto
{
  public class PostDto : BaseEntity
  {
    public string? PostedMessage { get; set; }

    public int PostedByUserId { get; set; }

    public string PostedByUserName { get; set; }

    public int PostedToUserId { get; set; }

    public DateTime PostedTime { get; set; } = DateTime.Now;
  }
}