using Entity;
namespace API.Dto
{
  public class PostDto
  {
    public int Id { get; set; }

    public int UserId { get; set; }

    public string? PostedMessage { get; set; }

    public List<Comment>? Comments { get; set; }
  }
}