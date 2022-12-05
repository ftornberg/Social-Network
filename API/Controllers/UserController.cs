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

    [HttpPost("register")]
    public async Task<ActionResult<IReadOnlyList<UserRegisterDto>>> RegisterUser(UserRegisterDto userRegisterDto)
    {
      User user = new User
      (
        userRegisterDto.Name,
        userRegisterDto.Email,
        userRegisterDto.Password,
        DateTime.Now
      );

      if (user == null) return BadRequest();
      await _userRepository.AddAsync(user);

      return Ok();
    }

    [HttpGet("users")]
    public async Task<ActionResult<IReadOnlyList<UserDto>>> GetUsersAsync()
    {
      var users = await _userRepository.ListAllAsync();

      return Ok(users.Select(user => new UserDto
      {
        Id = user.Id,
        Name = user.Name,
        Email = user.Email
      }));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UserDto>> GetInfoAboutUserAsync(int id)
    {
      var user = await _userRepository.GetByIdAsync(id);

      return new UserDto
      {
        Id = user.Id,
        Name = user.Name,
        Email = user.Email,
      };
    }
  }
}