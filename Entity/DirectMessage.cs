namespace Entity;
public class DirectMessage : BaseEntity
{

  public int ConversationId { get; set; }

  public DateTime TimeSent { get; set; }

  public int Sender { get; set; }

  public int Reciever { get; set; }

  public string? Message { get; set; }
}