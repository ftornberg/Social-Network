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
    public async Task<ActionResult<FollowerDto>> FollowUserAsync(FollowerDto followNewUserDto)
    {
      var followNewUser = _mapper.Map<Follower>(followNewUserDto);
      var users = await _userRepository.ListAllAsync();

      if (followNewUser == null) return BadRequest();

      followNewUser.FollowerUserName = users.FirstOrDefault(u => u.Id == followNewUser.FollowerUserId).Name;
      followNewUser.FollowsUserName = users.FirstOrDefault(u => u.Id == followNewUser.FollowsUserId).Name;

      var followNewUserCreated = await _followerRepository.AddAsync(followNewUser);
      var followNewUserCreatedDto = _mapper.Map<FollowerDto>(followNewUserCreated);

        return followNewUserCreatedDto;
    }

    [HttpGet("GetFollowersForUser/{followedUserId}")]
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
