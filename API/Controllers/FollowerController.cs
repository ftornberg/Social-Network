using API.Dto.Follower;
using AutoMapper;
using Entity;
using Entity.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
  public class FollowerController : BaseController
  {
    private readonly IGenericRepository<Follower> _followerRepository;
    private readonly IMapper _mapper;

    public FollowerController(IGenericRepository<Follower> followerRepository, IMapper mapper)
    {
      _followerRepository = followerRepository;
      _mapper = mapper;
    }

    [HttpPost("FollowUser")]
    [ResponseCache(VaryByHeader = "User-Agent", Duration = 5)]
    public async Task<ActionResult<FollowerDto>> FollowUserAsync(FollowerDto followNewUserDto)
    {
      var followNewUser = _mapper.Map<Follower>(followNewUserDto);

      if (followNewUser == null) return BadRequest();
      var followNewUserCreated = await _followerRepository.AddAsync(followNewUser);
      var followNewUserCreatedDto = _mapper.Map<FollowerDto>(followNewUserCreated);

      return followNewUserCreatedDto;
    }

    [HttpGet("GetFollowersForUser/{followedUserId}")]
    [ResponseCache(VaryByHeader = "User-Agent", Duration = 5)]
    public async Task<ActionResult<IReadOnlyList<FollowerDto>>> GetFollowersForUserAsync(int followedUserId)
    {
      var allFollowers = await _followerRepository.ListAllAsync();

      IReadOnlyList<Follower> followers = allFollowers
      .Where(follower => follower.FollowsUserId == followedUserId)
      .OrderBy(follower => follower.Id)
      .ToList();

      var followersDto = _mapper.Map<List<FollowerDto>>(followers);

      return followersDto;
    }
  }
}