using System.ComponentModel.DataAnnotations.Schema;

namespace Entity;
public class DirectMessage : BaseEntity
{
    public DirectMessage()
    {
    }

    public DirectMessage(int senderUserId, string senderUserName, int receiverUserId, string receiverUserName, string message, DateTime timeSent)
    {
        SenderUserId = senderUserId;
        SenderUserName = senderUserName;
        ReceiverUserId = receiverUserId;
        ReceiverUserName = receiverUserName;
        Message = message;
        TimeSent = timeSent;
    }

    [ForeignKey("UserId")]
    public int SenderUserId { get; set; }

    [ForeignKey("UserName")]
    public string SenderUserName { get; set; }

    [ForeignKey("UserId")]
    public int ReceiverUserId { get; set; }

    [ForeignKey("UserName")]
    public string ReceiverUserName { get; set; }

    public string Message { get; set; } = string.Empty;

    public DateTime TimeSent { get; set; }
}