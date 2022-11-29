using Entity;
using Entity.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
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

  }
}