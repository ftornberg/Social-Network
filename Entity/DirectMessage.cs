namespace Entity;
public class DirectMessage
{
    public Guid MessageId { get; set; }
    
    public DateTime TimeSent {get; set;}

    public Guid Sender { get; set; }

    public Guid Reciever { get; set; }

    public string? Message { get; set; }
}