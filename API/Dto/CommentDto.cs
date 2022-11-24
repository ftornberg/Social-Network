using Entity;

namespace API.Dto
{
    public class CommentDto
    {
        public User PostedBy { get; set; }

        public string? Message { get; set; }

        public DateTime CommentedTime { get; set; }
    }
}