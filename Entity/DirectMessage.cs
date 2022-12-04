namespace Entity;
public class DirectMessage : BaseEntity
{
  public DateTime TimeSent { get; set; }

  public int Sender { get; set; }

  public int Receiver { get; set; }

  public string? Message { get; set; }
}