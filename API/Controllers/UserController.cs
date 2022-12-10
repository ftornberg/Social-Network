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
    public async Task<ActionResult<UserGetDto>> RegisterUserAsync(UserAddDto userRegisterDto)
    {
        var user = _mapper.Map<User>(userRegisterDto);
        user.CreatedTime = DateTime.Now;
        
        var userCreated = await _userRepository.AddAsync(user);
        var userCreatedDto = _mapper.Map<UserGetDto>(userCreated);

        // Fulfix pga bugg
        userCreatedDto.CreatedTime = user.CreatedTime;

        return userCreatedDto;
    }

    [HttpGet("GetUsers")]
    public async Task<ActionResult<IReadOnlyList<UserGetDto>>> GetUsersAsync()
    {
        var users = await _userRepository.ListAllAsync();
        if (users.Count == 0) return BadRequest(new ApiResponse(400, "There are no users."));
        
        var userDto = _mapper.Map<List<UserGetDto>>(users);

        return userDto;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UserGetDto>> GetUserByIdAsync(int id)
    {
        var user = await _userRepository.GetByIdAsync(id);
        if (user == null) return BadRequest(new ApiResponse(400, "This user does not exist."));

        var UserDto = _mapper.Map<UserGetDto>(user);

        return UserDto;
    }
}
