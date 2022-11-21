namespace Entity
{
    public class UsersFollowing : User
    {
        public Guid UserId { get; set; }

        public List<User>? FollowingUsers { get; set; }
    }
}