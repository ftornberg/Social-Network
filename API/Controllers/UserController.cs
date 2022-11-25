using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity.Interfaces;
using Entity;

namespace API.Controllers
{
  public class UserController : BaseController
  {
    private readonly IGenericRepository<User> _userRepository;

    public UserController(IGenericRepository<User> userRepository)
    {
      _userRepository = userRepository;
    }

    public Task<Entity.User> GetUserById(int id)
    {
      return _userRepository.GetByIdAsync(id);
    }

  }

}