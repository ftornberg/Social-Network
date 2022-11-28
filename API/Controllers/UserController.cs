using Entity;
using Entity.Interfaces;
using Microsoft.AspNetCore.Mvc;
using API.Dto;

namespace API.Controllers
{
  public class UserController : BaseController
  {
    private readonly IGenericRepository<User> _userRepository;

    public UserController(IGenericRepository<User> userRepository)
    {
      _userRepository = userRepository;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UserDto>> GetInfoAboutUserAsync(int id)
    {
      var user = await _userRepository.GetByIdAsync(id);

      return new UserDto
      {
        Name = user.Name,
        Email = user.Email,
      };
    }
  }
}