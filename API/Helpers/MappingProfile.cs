using Entity;
using API.Dto;
using AutoMapper;

namespace API.Helpers
{
  public class MappingProfile : Profile
  {
    public MappingProfile()
    {
      CreateMap<User, UserDto>();

      CreateMap<User, FollowersDto>();

      CreateMap<DirectMessage, DirectMessageDto>();

      CreateMap<Post, PostDto>();

      CreateMap<Comment, CommentDto>();

      CreateMap<Conversation, ConversationDto>();
    }
  }
}