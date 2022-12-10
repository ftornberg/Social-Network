using API.Dto.User;

namespace API.Controllers;

public class UserController : BaseController
{
    private readonly IGenericRepository<User> _userRepository;
    private readonly IMapper _mapper;

    public UserController(IGenericRepository<User> userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    [HttpPost("RegisterUser")]
    public async Task<ActionResult<UserRegisterDto>> RegisterUserAsync(UserRegisterDto userRegisterDto)
    {
        var user = _mapper.Map<User>(userRegisterDto);
        
        var userCreated = await _userRepository.AddAsync(user);
        var userCreatedDto = _mapper.Map<UserDto>(userCreated);

        return userCreatedDto;
    }

    [HttpGet("Users")]
    public async Task<ActionResult<IReadOnlyList<UserDto>>> GetUsersAsync()
    {
        var users = await _userRepository.ListAllAsync();
        if (users.Count == 0) return BadRequest(new ApiResponse(400, "There are no users."));
        
        var userDto = _mapper.Map<List<UserDto>>(users);

        return userDto;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UserDto>> GetUserByIdAsync(int id)
    {
        var user = await _userRepository.GetByIdAsync(id);
        if (user == null) return BadRequest(new ApiResponse(400, "This user does not exist."));

        var UserDto = _mapper.Map<UserDto>(user);

        return UserDto;
    }
}
