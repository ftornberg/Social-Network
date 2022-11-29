using Entity;
using Entity.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
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
    public async Task<ActionResult<IReadOnlyList<RegisterUserDto>>> RegisterUser(User user)
    {
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

  }
}