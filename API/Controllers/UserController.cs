using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;
using Entity.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;



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

    public async Task<User> GetUserById(int id)
    {
      return await _userRepository.GetByIdAsync(id);
    }

    //   [HttpPost]

    //   public async Task<User> AddFollowerAsync(User newUserFollower, User userToBeFollowed)
    //   {
    //     return await _userRepository.AddAsync(newUserFollower.Id).ToListAsyc(userToBeFollowed.Followers);
    //   }

    //   [HttpGet("{id}")]
    //   public async Task<User> GetFollowersAsync(int id)
    //   {
    //     return await _userRepository.GetByIdAsync(id);
    //   }
  }
}