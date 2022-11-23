using Entity;
using API.Dto;
using AutoMapper;

namespace API.Helpers
{
  public class MappingProfiles : Profile
  {
    public MappingProfiles()
    {
      CreateMap<User, UserDto>();

      CreateMap<User, FollowersDto>();

      CreateMap<DirectMessage, DirectMessageDto>();

      CreateMap<Post, PostDto>();

      CreateMap<Post.Comment, CommentDto>();
    }
  }
}