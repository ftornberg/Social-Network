using Entity;
using Entity.Interfaces;
using Microsoft.AspNetCore.Mvc;
using API.Dto;
using AutoMapper;
using Infrastructure;
namespace API.Controllers
{
  public class UserController : BaseController
  {
    private readonly IGenericRepository<User> _userRepository;
    private readonly IMapper _mapper;
    private readonly NetworkContext _context;

    public UserController(IGenericRepository<User> userRepository, IMapper mapper, NetworkContext context)
    {
      _userRepository = userRepository;
      _mapper = mapper;
      _context = context;
    }

    [HttpPost("register")]
    public async Task<ActionResult<IReadOnlyList<RegisterUserDto>>> RegisterUser(RegisterUserDto registerUserDto)
    {
      User user = new User 
      (
        registerUserDto.Name,
        registerUserDto.Email,
        registerUserDto.Password,
        DateTime.Now
      );

        _context.Users?.Add(user);

        var result = await _context.SaveChangesAsync() > 0;

        return result ? Ok() : BadRequest();
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<UserDto>>> GetUsers()
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

    [HttpDelete]
    public async Task<ActionResult<bool>> DeleteUser(string email, string password)
    {
      var user = await GetUserByEmailAsync(email);

      if (user?.Value?.Password != password) return BadRequest();
      var entity = await _userRepository.GetByIdAsync(user.Value.Id);

      await _userRepository.DeleteAsync(entity);

      return true;
    }

    private async Task<ActionResult<UserDto>?> GetUserByEmailAsync(string email)
    {
      var users = await _userRepository.ListAllAsync();
      try
      {
        var user = users.FirstOrDefault(u => u.Email == email);
        UserDto userDto = new UserDto{ Email = user.Email, Password = user.Password, Name = user.Name, Id = user.Id };
        return userDto;
      }
      catch (Exception ex)
      {
        return BadRequest(ex);
      }
    }
  }
}