using Microsoft.AspNetCore.Identity;
using Entity;
namespace API.Dto;

public class User
{
    public List<User>? Followers { get; set; }

    public List<Post>? Posts { get; set; }

    public List<DirectMessage>? Messages { get; set; }
}