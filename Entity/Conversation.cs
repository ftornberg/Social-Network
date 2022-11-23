namespace Entity;
public class Conversation
{
    public Guid ConversationId { get; set; }

    public List<DirectMessage>? Messages { get; set; }
}