using Entity;
using API.Dto;
using AutoMapper;
using API.Dto.Follower;

namespace API.Helpers
{
  public class MappingProfile : Profile
  {
    public MappingProfile()
    {
      CreateMap<User, UserDto>().ReverseMap();

      CreateMap<Follower, FollowerDto>().ReverseMap();

      CreateMap<DirectMessage, DirectMessageDto>().ReverseMap();

      CreateMap<Post, PostDto>().ReverseMap();

      CreateMap<Comment, CommentDto>().ReverseMap();

    }
  }
}