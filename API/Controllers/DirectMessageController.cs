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

    var sender = await _userRepository.GetByIdAsync(directMessage.SenderUserId);
    var receiver = await _userRepository.GetByIdAsync(directMessage.ReceiverUserId);

    if (sender == null || receiver == null) return BadRequest();

    directMessage.SenderUserName = sender.Name;
    directMessage.ReceiverUserName = receiver.Name;

    var directMessageCreated = await _directMessageRepository.AddAsync(directMessage);
    var directMessageCreatedDto = _mapper.Map<DirectMessageDto>(directMessageCreated);

    return directMessageCreatedDto;
  }

  [HttpGet("GetMessages/{userOneId}/{userTwoId}")]
  public async Task<ActionResult<IReadOnlyList<DirectMessageDto>>> GetMessagesAsync(int userOneId, int userTwoId)
  {
    var directMessages = await _directMessageRepository.ListAllAsync();
    var users = await _userRepository.ListAllAsync();

    IReadOnlyList<DirectMessage> messagesFromUserOne = directMessages
    .Where(message =>
        (message.SenderUserId == userOneId && message.ReceiverUserId == userTwoId)
        || (message.SenderUserId == userTwoId && message.ReceiverUserId == userOneId))
    .OrderByDescending(message => message.TimeSent)
    .ToList();

    var messagesDto = _mapper.Map<List<DirectMessageDto>>(messagesFromUserOne);

    return messagesDto;
  }

  [HttpGet("GetAllConversationsForUser/{userId}")]
  public async Task<ActionResult<IReadOnlyList<DirectMessageConversationDto>>> GetAllConversationsForUserAsync(int userId)
  {
    var directMessages = await _directMessageRepository.ListAllAsync();

    List<DirectMessageConversationDto> tempDtoList = new List<DirectMessageConversationDto>();

    // Create list of conversations based on sent by user
    var conversationSent = directMessages
    .Where(message => message.SenderUserId == userId)
    .OrderByDescending(message => message.TimeSent)
    .ToList();

    foreach (var message in conversationSent)
    {
      if (tempDtoList.All(dto => dto.UserId != message.ReceiverUserId))
        tempDtoList.Add(new DirectMessageConversationDto
        {
          UserId = message.ReceiverUserId,
          UserName = message.ReceiverUserName
        });
    }

    // Create list of conversations based on recieved by user
    var conversationRecieved = directMessages
    .Where(message => message.ReceiverUserId == userId)
    .OrderByDescending(message => message.TimeSent)
    .ToList();

    foreach (var message in conversationRecieved)
    {
      if (tempDtoList.All(dto => dto.UserId != message.SenderUserId))
        tempDtoList.Add(new DirectMessageConversationDto
        {
          UserId = message.SenderUserId,
          UserName = message.SenderUserName
        });
    }

    return tempDtoList;
  }
}
