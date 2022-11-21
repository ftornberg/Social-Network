namespace Entity;
public class Conversation
{
    public Guid ConversationId { get; set; }

    public Guid Sender { get; set; }

    public Guid Reciever { get; set; }

    public List<DirectMessage>? Messages { get; set; }
}