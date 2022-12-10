using API.Dto.DirectMessage;

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
  public async Task<ActionResult<DirectMessage>> SendMessageAsync(DirectMessageAddDto directMessageDto)
  {
    var directMessage = _mapper.Map<DirectMessage>(directMessageDto);
    directMessage.TimeSent = DateTime.Now;

    var sender = await _userRepository.GetByIdAsync(directMessage.SenderUserId);
    if (sender == null) return BadRequest(new ApiResponse(400, "The user sending the message was not found."));
    directMessage.SenderUserName = sender.Name;

    var receiver = await _userRepository.GetByIdAsync(directMessage.ReceiverUserId);
    if (receiver == null) return BadRequest(new ApiResponse(400, "The user receiveing the message was not found."));
    directMessage.ReceiverUserName = receiver.Name;

    var directMessageCreated = await _directMessageRepository.AddAsync(directMessage);
    var directMessageCreatedDto = _mapper.Map<DirectMessageGetDto>(directMessageCreated);
    
    // Fulfix pga bugg
    directMessageCreatedDto.TimeSent = directMessageCreated.TimeSent;

    return directMessageCreated;
  }

  [HttpGet("GetMessages/{userOneId}/{userTwoId}")]
  public async Task<ActionResult<IReadOnlyList<DirectMessageGetDto>>> GetMessagesAsync(int userOneId, int userTwoId)
  {
    var directMessages = await _directMessageRepository.ListAllAsync();
    if (directMessages.Count == 0) return BadRequest(new ApiResponse(400, "There are no direct messages."));

    IReadOnlyList<DirectMessage> messagesFromUserOne = directMessages
    .Where(message =>
        (message.SenderUserId == userOneId && message.ReceiverUserId == userTwoId)
        || (message.SenderUserId == userTwoId && message.ReceiverUserId == userOneId))
    .OrderByDescending(message => message.TimeSent)
    .ToList();

    var messagesDto = _mapper.Map<List<DirectMessageGetDto>>(messagesFromUserOne);

    return messagesDto;
  }

  [HttpGet("GetAllConversationsForUser/{userId}")]
  public async Task<ActionResult<IReadOnlyList<DirectMessageConversationDto>>> GetAllConversationsForUserAsync(int userId)
  {
    var directMessages = await _directMessageRepository.ListAllAsync();
    if (directMessages.Count == 0) return BadRequest(new ApiResponse(400, "There are no direct messages."));

    List<DirectMessageConversationDto> tempDtoList = new List<DirectMessageConversationDto>();

    var conversations = directMessages
    .Where(message => message.SenderUserId == userId || message.ReceiverUserId == userId)
    .OrderByDescending(message => message.TimeSent)
    .ToList();

    foreach (var message in conversations)
    {
      // Adds to list of conversations based on sent by user
      if (tempDtoList.All(dto => dto.UserId != message.ReceiverUserId))
        tempDtoList.Add(new DirectMessageConversationDto
        {
          Id = tempDtoList.Count,
          UserId = message.ReceiverUserId,
          UserName = message.ReceiverUserName
        });
        
      // Adds to list of conversations based on recieved by user
      else if (tempDtoList.All(dto => dto.UserId != message.SenderUserId))
        tempDtoList.Add(new DirectMessageConversationDto
        {
          Id = tempDtoList.Count,
          UserId = message.SenderUserId,
          UserName = message.SenderUserName
        });
    }

    return tempDtoList;
  }
}
