using API.Dto.Comment;
using API.Dto.DirectMessage;
using API.Dto.Follower;
using API.Dto.Post;
using API.Dto.User;

namespace API.Helpers;

public class MappingProfile : Profile
{
  public MappingProfile()
  {
    CreateMap<User, UserDto>().ReverseMap();

    CreateMap<User, UserRegisterDto>().ReverseMap();

    CreateMap<User, UserCredentialsDto>().ReverseMap();

    CreateMap<Follower, FollowerDto>().ReverseMap();

    CreateMap<DirectMessage, DirectMessageDto>().ReverseMap();

    CreateMap<Post, PostDto>().ReverseMap();

    CreateMap<Comment, CommentDto>().ReverseMap();
  }
}
