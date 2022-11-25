using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;
using Entity.Interfaces;
using Microsoft.EntityFrameworkCore;
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

    /*public async Task<ActionResult<UserDto>> GetUserById(int id)
    {
      return await _userRepository.GetByIdAsync(id);
    }
*/

    [HttpGet("{id}")] //
    public async Task<ActionResult<UserDto>> GetUserById(int userId)
    {
      var course = await _userRepository.GetByIdAsync(userId);

      var user = await _userManager.FindByNameAsync(User.Identity.Name);

      var sections = await _context.Sections.Where(x => x.CourseId == course.Id).Include(c => c.Lectures).ToListAsync();

      var userCourse = _context.UserCourses.Where(x => x.User == user).Where(x => x.Course == course).First();

      return new UserDto
      {
        CourseName = course.Title,
        Sections = _mapper.Map<List<Section>, List<SectionDto>>(sections),
        CurrentLecture = userCourse.CurrentLecture
      };
    }


    // {
    //   return await _userRepository.GetByIdAsync(id);

    // }

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