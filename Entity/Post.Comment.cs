namespace Entity;
public partial class Post
{
  public class Comment : Post
  {
        public Comment(Post? postId)
        {
            PostId = postId;
        }
        
        public int Id { get; set; }

        public Post? PostId { get; set; }


        public string? Message { get; set; }

        public DateTime CommentedTime { get; set; }
    
        public int UserId { get; set; }
  }
}