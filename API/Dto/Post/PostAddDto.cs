namespace API.Dto.Post;

public class PostAddDto
{
    public string? PostedMessage { get; set; }

    public int PostedByUserId { get; set; }

    public int PostedToUserId { get; set; }
}