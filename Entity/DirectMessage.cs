namespace Entity;
public class DirectMessage : BaseEntity
{
    public DirectMessage()
    {
    }
    
    public DirectMessage(int sender, int receiver, string message, DateTime timeSent)
    {
        Sender = sender;
        Receiver = receiver;
        Message = message;
        TimeSent = timeSent;
    }

    public int Sender { get; set; }

    public int Receiver { get; set; }

    public string Message { get; set; }

    public DateTime TimeSent { get; set; }
}