using Entity;
using Entity.Interfaces;
using Microsoft.AspNetCore.Mvc;
using API.Dto;
using AutoMapper;


namespace API.Controllers
{
  public class UserController : BaseController
  {
    private readonly IGenericRepository<User> _userRepository;
    private readonly IMapper _mapper;

    public UserController(IGenericRepository<User> userRepository, IMapper mapper)
    {
      _userRepository = userRepository;
      _mapper = mapper;
    }

    [HttpPost("Register")]
    [ResponseCache(VaryByHeader = "User-Agent", Duration = 5)]
    public async Task<ActionResult<UserRegisterDto>> RegisterUser(UserRegisterDto userRegisterDto)
    {
      var user = _mapper.Map<User>(userRegisterDto);

      if (user == null) return BadRequest();
      var userCreated = await _userRepository.AddAsync(user);
      var userCreatedDto = _mapper.Map<UserDto>(userCreated);
      
      return userCreatedDto;
    }

    [HttpGet("Users")]
    [ResponseCache(VaryByHeader = "User-Agent", Duration = 5)]
    public async Task<ActionResult<IReadOnlyList<UserDto>>> GetUsersByListAllAsync()
    {
      var users = await _userRepository.ListAllAsync();
      var userDto = _mapper.Map<List<UserDto>>(users);

      return userDto;
    }

    [HttpGet("{id}")]
    [ResponseCache(VaryByHeader = "User-Agent", Duration = 5)]
    public async Task<ActionResult<UserDto>> GetUserByIdAsync(int id)
    {
      var user = await _userRepository.GetByIdAsync(id);
      var UserDto = _mapper.Map<UserDto>(user);

      return UserDto;
    }
  }
}