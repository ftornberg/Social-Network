namespace API.Dto.DirectMessage;

public class DirectMessageAddDto
{
  public int SenderUserId { get; set; }

  public int ReceiverUserId { get; set; }

  public string? Message { get; set; }
}