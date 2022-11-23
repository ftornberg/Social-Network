namespace Entity;
public class Conversation
{
    public int ConversationId { get; set; }

    public List<DirectMessage>? Messages { get; set; }
}