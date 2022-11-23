using System.Collections.Generic;
using Entity;

namespace API.Dto 
{
    public class FollowersDto
    {
        public  List<User>? Followers { get; set; }
    }
}