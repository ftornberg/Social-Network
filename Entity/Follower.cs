
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity
{
    public class Follower : BaseEntity
    {
    public Follower()
    {
    }

    public Follower(int followerUserId, int followsUserId)
    {
        FollowerUserId = followerUserId;
        FollowsUserId = followsUserId;
    }

        [ForeignKey("UserId")]
        public int FollowerUserId { get; set; }

        public int FollowsUserId { get; set; }
    }
}