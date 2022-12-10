namespace API.Dto.Post;

public class PostGetDto : BaseEntity
{
    public string? PostedMessage { get; set; }

    public int PostedByUserId { get; set; }

    public string? PostedByUserName { get; set; }

    public int PostedToUserId { get; set; }

    public DateTime PostedTime { get; set; }
}