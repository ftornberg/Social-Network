using Entity;
using API.Dto;
using AutoMapper;

namespace API.Helpers
{
  public class MappingProfile : Profile
  {
    public MappingProfile()
    {
      CreateMap<User, UserDto>().ReverseMap();

      CreateMap<User, FollowersDto>().ReverseMap();

      CreateMap<DirectMessage, DirectMessageDto>().ReverseMap();

      CreateMap<Post, PostDto>().ReverseMap();

      CreateMap<Comment, CommentDto>().ReverseMap();
    }
  }
}