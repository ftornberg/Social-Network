namespace API.Dto.DirectMessage;

public class DirectMessageConversationDto : BaseEntity
{
  public int UserId { get; set; }

  public string? UserName { get; set; }
}