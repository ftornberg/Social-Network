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
    CreateMap<User, UserAddDto>().ReverseMap();

    CreateMap<User, UserGetDto>().ReverseMap();

    CreateMap<Follower, FollowerAddDto>().ReverseMap();

    CreateMap<Follower, FollowerGetDto>().ReverseMap();

    CreateMap<DirectMessage, DirectMessageAddDto>().ReverseMap();

    CreateMap<DirectMessage, DirectMessageGetDto>().ReverseMap();

    CreateMap<Post, PostAddDto>().ReverseMap();

    CreateMap<Post, PostGetDto>().ReverseMap();

    CreateMap<Comment, CommentDto>().ReverseMap();
  }
}
