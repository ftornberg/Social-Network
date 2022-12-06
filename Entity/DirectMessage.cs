namespace Entity;
public class DirectMessage : BaseEntity
{
  public DateTime TimeSent { get; set; }

  public int Sender { get; set; }

  public int Receiver { get; set; }

  public string Message { get; set; }

    public DirectMessage(int sender, int receiver, string message, DateTime timeSent)
  {
    Sender = sender;
    Receiver = receiver;
    Message = message;
    TimeSent = timeSent;
  }
}