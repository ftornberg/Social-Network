namespace Entity;
public partial class Post
{
    public int Id { get; set; }
    
    public int UserId { get; set; }

    public string? PostedMessage { get; set; }

    public List<Comment>? Comments { get; set; }

    public DateTime PostedTime { get; set; }
    
}