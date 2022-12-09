namespace API.Dto.DirectMessage;

public class DirectMessageDto : BaseEntity
{
    public int SenderUserId { get; set; }

    public string? SenderUserName { get; set; }

    public int ReceiverUserId { get; set; }

    public string? ReceiverUserName { get; set; }

    public string? Message { get; set; }

    public DateTime TimeSent { get; set; } = DateTime.Now;
}