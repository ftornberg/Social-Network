namespace API.Dto.Comment;

    public class CommentDto
{
    public int PostId { get; set; }

    public int CommentedByUserId { get; set; }

    public string? Message { get; set; }

    public DateTime CommentedTime { get; set; }
}