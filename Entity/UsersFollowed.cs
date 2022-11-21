namespace Entity
{
    public class UsersFollowed : User
    {
        public Guid UserId { get; set; }

        public List<User>? FollowedUsers { get; set; }
    }
}