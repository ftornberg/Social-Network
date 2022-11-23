using Microsoft.AspNetCore.Identity;
using Entity;
namespace API.Dto;

public class UserDto
{
    public List<UserDto>? Followers { get; set; }

    public List<Post>? Posts { get; set; }

    public List<DirectMessage>? Messages { get; set; }
}