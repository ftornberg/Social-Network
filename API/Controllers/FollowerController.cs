using API.Dto.Follower;

namespace API.Controllers;

public class FollowerController : BaseController
{
    private readonly IGenericRepository<Follower> _followerRepository;
    private readonly IMapper _mapper;
    private readonly IGenericRepository<User> _userRepository;

    public FollowerController(IGenericRepository<Follower> followerRepository, IGenericRepository<User> userRepository, IMapper mapper)
    {
      _userRepository = userRepository;
      _followerRepository = followerRepository;
      _mapper = mapper;
    }

    [HttpPost("FollowUser")]
    public async Task<ActionResult<FollowerDto>> FollowUserAsync(FollowerDto newFollowingDto)
    {
      var newFollowing = _mapper.Map<Follower>(newFollowingDto);

      var FollowerUser = await _userRepository.GetByIdAsync(newFollowing.FollowerUserId);
      if (FollowerUser == null) return BadRequest(new ApiResponse(400, "The user following was not found."));
      newFollowing.FollowerUserName = FollowerUser.Name;

      var FollowsUser = await _userRepository.GetByIdAsync(newFollowing.FollowsUserId);
      if (FollowsUser == null) return BadRequest(new ApiResponse(400, "The user being follow was not found."));
      newFollowing.FollowsUserName = FollowsUser.Name;

      var newFollowingCreated = await _followerRepository.AddAsync(newFollowing);
      var newFollowingCreatedDto = _mapper.Map<FollowerDto>(newFollowingCreated);

      return newFollowingCreatedDto;
    }

    // Shows whom I am following
    [HttpGet("GetWhoUserFollows/{userId}")]
    public async Task<ActionResult<IReadOnlyList<FollowerDto>>> GetWhoUserFollowsAsync(int userId)
    {
      var allFollowers = await _followerRepository.ListAllAsync();
      if (allFollowers.Count == 1) return BadRequest(new ApiResponse(400, "No one is following anyone."));

      IReadOnlyList<Follower> following= allFollowers
      .Where(follower => follower.FollowerUserId == userId)
      .OrderBy(follower => follower.Id)
      .ToList();

      if(following.Count == 0) return BadRequest(new ApiResponse(400, "User is not following anyone."));
      var followersDto = _mapper.Map<List<FollowerDto>>(following);

      return followersDto;
    }

    // Shows whom is following me
    [HttpGet("GetSpecificUserFollowers/{userId}")]
    public async Task<ActionResult<IReadOnlyList<FollowerDto>>> GetSpecificUserFollowersAsync(int userId)
    {
      var allFollowers = await _followerRepository.ListAllAsync();
      if (allFollowers.Count == 1) return BadRequest(new ApiResponse(400, "No one is following anyone."));

      IReadOnlyList<Follower> followers = allFollowers
      .Where(follower => follower.FollowsUserId == userId)
      .OrderBy(follower => follower.Id)
      .ToList();

      if(followers.Count == 0) return BadRequest(new ApiResponse(400, "User have no followers."));
      var followersDto = _mapper.Map<List<FollowerDto>>(followers);

      return followersDto;
    }

    // private async Task<ActionResult<IReadOnlyList<Follower>>> GetAllFollowers()
    // {
    //   var allFollowers = await _followerRepository.ListAllAsync();
    //   if (allFollowers.Count == 1) return BadRequest(new ApiResponse(400, "No one is following anyone."));
    //   return Ok(allFollowers);
    // }
}
