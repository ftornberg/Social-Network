using System.Collections.Generic;
using Entity;

namespace API.Dto 
{
    public class FollowersDto
    {
        public  ICollection<User>? Followers { get; set; }
    }
}