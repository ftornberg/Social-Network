namespace API.Dto.Follower
{
    public class FollowerDto
    {
        public int FollowerUserId { get; set; }

        public string FollowerUserName { get; set; }
        
        public int FollowsUserId { get; set; }

        public string FollowsUserName { get; set; }

    }
}