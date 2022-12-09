namespace API.Controllers;

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
  public async Task<ActionResult<DirectMessageDto>> SendMessageAsync(DirectMessageDto directMessageDto)
  {
    var directMessage = _mapper.Map<DirectMessage>(directMessageDto);
    var users = await _userRepository.ListAllAsync();

    var user = await _userRepository.GetByIdAsync(directMessage.ReceiverUserId);

    if (user == null)
      return BadRequest();

    directMessage.SenderUserName = users.FirstOrDefault(user => user.Id == directMessage.SenderUserId).Name;
    directMessage.ReceiverUserName = users.FirstOrDefault(user => user.Id == directMessage.ReceiverUserId).Name;

    var directMessageCreated = await _directMessageRepository.AddAsync(directMessage);
    var directMessageCreatedDto = _mapper.Map<DirectMessageDto>(directMessageCreated);

    return directMessageCreatedDto;
  }

  [HttpGet("GetMessages/{userOneId}/{userTwoId}")]
  public async Task<ActionResult<IReadOnlyList<DirectMessageDto>>> GetMessagesAsync(int userOneId, int userTwoId)
  {
    var directMessages = await _directMessageRepository.ListAllAsync();
    var users = await _userRepository.ListAllAsync();

    var userOne = await _userRepository.GetByIdAsync(userOneId);
    var userTwo = await _userRepository.GetByIdAsync(userTwoId);

    IReadOnlyList<DirectMessage> messagesFromUserOne = directMessages
    .Where(message => (message.SenderUserId == userOneId && message.ReceiverUserId == userTwoId))
    .OrderByDescending(message => message.TimeSent)
    .ToList();

    IReadOnlyList<DirectMessage> messagesFromUserTwo = directMessages
    .Where(message => (message.SenderUserId == userTwoId && message.ReceiverUserId == userOneId))
    .OrderByDescending(message => message.TimeSent)
    .ToList();

    var messages = messagesFromUserOne.Concat(messagesFromUserTwo)
        .OrderByDescending(message => message.TimeSent)
        .ToList();

    var messagesDto = _mapper.Map<List<DirectMessageDto>>(messages);

    return messagesDto;
  }
}
