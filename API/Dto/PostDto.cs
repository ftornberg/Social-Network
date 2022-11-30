using Entity;
namespace API.Dto
{
  public class PostDto : BaseEntity
  {
    public string? PostedMessage { get; set; }

    public ICollection<Comment>? Comments { get; set; }
  }
}