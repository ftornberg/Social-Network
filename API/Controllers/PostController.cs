using API.Dto.Post;

namespace API.Controllers;

    public class PostController : BaseController
{
    private readonly IGenericRepository<Post> _postRepository;
    private readonly IGenericRepository<Follower> _followerRepository;
    private readonly IMapper _mapper;
    private readonly IGenericRepository<User> _userRepository;

    public PostController(IGenericRepository<Post> postRepository, IMapper mapper, IGenericRepository<Follower> followerRepository, IGenericRepository<User> userRepository)
    {
        _userRepository = userRepository;
        _postRepository = postRepository;
        _mapper = mapper;
        _followerRepository = followerRepository;
    }

    [HttpPost("CreatePost")]
    public async Task<ActionResult<PostGetDto>> CreatePostAsync(PostAddDto postDto)
    {
        var post = _mapper.Map<Post>(postDto);
        post.PostedTime = DateTime.Now;

        var user = await _userRepository.GetByIdAsync(post.PostedToUserId);
        if (user == null) return BadRequest(new ApiResponse(400, "It is not possible to create a post because the user does not exist."));
        post.PostedByUserName = user.Name;

        var postCreated = await _postRepository.AddAsync(post);
        var postCreatedDto = _mapper.Map<PostGetDto>(postCreated);

        // Fulfix pga bugg
        postCreatedDto.PostedTime = postCreated.PostedTime;

        return postCreatedDto;
    }

    [HttpGet("GetAllPosts/{userId}")]
    public async Task<ActionResult<IReadOnlyList<PostGetDto>>> GetAllPostsAsync(int userId)
    {
        var allPosts = await _postRepository.ListAllAsync();
        if (allPosts == null) return BadRequest(new ApiResponse(400, "There are no posts."));

        var allFollows = await _followerRepository.ListAllAsync();
        if (allFollows == null) return BadRequest(new ApiResponse(400, "There are no users that follows another user."));

        var followers = allFollows.Where(follower => follower.FollowerUserId == userId);

        IReadOnlyList<Post> posts = allPosts
        .Where(post => followers.Any(t => t.FollowsUserId == post.PostedByUserId))
        .OrderByDescending(post => post.PostedTime)
        .ToList();

        if (posts.Count == 0) return BadRequest(new ApiResponse(400, "There are no posts for this specific user."));

        var postDto = _mapper.Map<List<PostGetDto>>(posts);

        return postDto;
    }

    [HttpGet("GetPostsToSpecificUser/{postedToUserId}")]
    public async Task<ActionResult<IReadOnlyList<PostGetDto>>> GetPostsToSpecificUserAsync(int postedToUserId)
    {
        var allPosts = await _postRepository.ListAllAsync();
        if (allPosts == null) return BadRequest(new ApiResponse(400, "There are no posts."));
        
        IReadOnlyList<Post> posts = allPosts
        .Where(post => post.PostedToUserId == postedToUserId)
        .OrderByDescending(posts => posts.PostedTime)
        .ToList();

        if (posts.Count == 0) return BadRequest(new ApiResponse(400, "There are no posts for this specific user."));

        var postDto = _mapper.Map<List<PostGetDto>>(posts);

        return postDto;
    }
}
