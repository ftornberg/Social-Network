namespace Entity;
public class Conversation : BaseEntity
{
    public ICollection<DirectMessage>? Messages { get; set; }
}