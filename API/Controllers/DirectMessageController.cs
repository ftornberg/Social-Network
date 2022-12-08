using Entity;
using Entity.Interfaces;
using Microsoft.AspNetCore.Mvc;
using API.Dto;
using AutoMapper;
using Infrastructure;

namespace API.Controllers
{
  public class DirectMessageController : BaseController
  {
    private readonly IGenericRepository<DirectMessage> _directMessageRepository;
    private readonly IMapper _mapper;
    private readonly IGenericRepository<User> _userRepository;

    public DirectMessageController(IGenericRepository<DirectMessage> directMessageRepository, IMapper mapper, IGenericRepository<User> userRepository)
    {
      _directMessageRepository = directMessageRepository;
      _mapper = mapper;
      _userRepository = userRepository;
    }

    [HttpPost("SendMessage")]
    [ResponseCache(VaryByHeader = "User-Agent", Duration = 5)]
    public async Task<ActionResult<DirectMessageDto>> SendMessageAsync(DirectMessageDto directMessageDto)
    {
      var directMessage = _mapper.Map<DirectMessage>(directMessageDto);

      var user = await _userRepository.GetByIdAsync(directMessage.Receiver);

      if (user == null)
        return BadRequest();

      var directMessageCreated = await _directMessageRepository.AddAsync(directMessage);
      var directMessageCreatedDto = _mapper.Map<DirectMessageDto>(directMessageCreated);

      return directMessageCreatedDto;
    }

    [HttpGet("GetMessages/{userOne}/{userTwo}")]
    [ResponseCache(VaryByHeader = "User-Agent", Duration = 5)]
    public async Task<ActionResult<IReadOnlyList<DirectMessageDto>>> GetMessagesAsync(int userOne, int userTwo)
    {
      var directMessages = await _directMessageRepository.ListAllAsync();

      IReadOnlyList<DirectMessage> messages = directMessages
      .Where(message => (message.Sender == userOne && message.Receiver == userTwo) || (message.Sender == userTwo && message.Receiver == userOne))
      .OrderByDescending(message => message.TimeSent)
      .ToList();

      var messagesDto = _mapper.Map<List<DirectMessageDto>>(messages);

      return messagesDto;
    }
  }
}