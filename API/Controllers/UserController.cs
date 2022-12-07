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

    [HttpGet("Users")]
    [ResponseCache(VaryByHeader = "User-Agent", Duration = 5)]
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
    [ResponseCache(VaryByHeader = "User-Agent", Duration = 5)]
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

    // To Be Removed Later In The Project

    // [HttpDelete("delete")]
    // public async Task<ActionResult<bool>> DeleteUserAsync(UserCredentialsDto userCredentialsDto)
    // {

    //   var user = await ValidateUserAsync(userCredentialsDto.Email, userCredentialsDto.Password);

    //   await _userRepository.DeleteAsync(user.Value);

    //   return true;
    // }

    // [HttpPut("update")]
    // public async Task<ActionResult<User>> UpdateUserAsync(UserUpdateDto userUpdateDto)
    // {
    //   var user = await ValidateUserAsync(userUpdateDto.Email, userUpdateDto.Password);

    //   if (user.Value.Name == userUpdateDto.OldProperty)
    //     user.Value.Name = userUpdateDto.UpdatedProperty;

    //   if (user.Value.Email == userUpdateDto.OldProperty)
    //     user.Value.Email = userUpdateDto.UpdatedProperty;

    //   if (user.Value.Password == userUpdateDto.OldProperty)
    //     user.Value.Password = userUpdateDto.UpdatedProperty;

    //   _context.Users?.Update(user.Value);
    //   var result = await _context.SaveChangesAsync() > 0;

    //   return result ? Ok() : BadRequest();
    // }

    // private async Task<ActionResult<User>> ValidateUserAsync(string email, string password)
    // {
    //   var user = await GetUserByEmailAsync(email);

    //   if (user?.Value?.Password != password) return BadRequest();
    //   var entity = await _userRepository.GetByIdAsync(user.Value.Id);

    //   return entity;
    // }

    // private async Task<ActionResult<UserDto>?> GetUserByEmailAsync(string email)
    // {
    //   var users = await _userRepository.ListAllAsync();
    //   try
    //   {
    //     var user = users.FirstOrDefault(u => u.Email == email);
    //     UserDto userDto = new UserDto { Email = user.Email, Password = user.Password, Name = user.Name, Id = user.Id };
    //     return userDto;
    //   }
    //   catch (Exception)
    //   {
    //     return BadRequest();
    //   }
    // }
  }
}