namespace Entity;
public class Conversation
{
  public int Id { get; set; }

  public List<DirectMessage>? Messages { get; set; }
}