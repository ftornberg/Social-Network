using Microsoft.AspNetCore.Identity;

namespace Entity;

public class User
{
    public List<User>? Followers { get; set; }

    public List<Post>? Posts { get; set; }

    public List<DirectMessage>? Messages { get; set; }
}