using API.Dto;
using AutoMapper;
using Entity;
using Entity.Interfaces;
using Microsoft.AspNetCore.Mvc;
namespace API.Controllers
{
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
    [ResponseCache(VaryByHeader = "User-Agent", Duration = 5)]
    public async Task<ActionResult<PostDto>> CreatePostAsync(PostDto postDto)

    {
      var post = _mapper.Map<Post>(postDto);
      var users = await _userRepository.ListAllAsync();
      post.PostedByUserName = users.FirstOrDefault(u => u.Id == post.PostedByUserId).Name;

      if (post == null) return BadRequest();
      var postCreated = await _postRepository.AddAsync(post);
      var postCreatedDto = _mapper.Map<PostDto>(postCreated);

      return postCreatedDto;
    }

    [HttpGet("GetAllPosts/{userId}")]
    [ResponseCache(VaryByHeader = "User-Agent", Duration = 5)]
    public async Task<ActionResult<IReadOnlyList<PostDto>>> GetAllPostsAsync(int userId)
    {
      var allPosts = await _postRepository.ListAllAsync();
      var followers = await _followerRepository.ListAllAsync();

      var temp = followers.Where(follower => follower.FollowerUserId == userId);

      IReadOnlyList<Post> posts = allPosts
      .Where(post => temp.Any(t => t.FollowsUserId == post.PostedByUserId))
      .OrderByDescending(post => post.PostedTime).ToList();

      var postDto = _mapper.Map<List<PostDto>>(posts);

      return postDto;
    }

    [HttpGet("GetPostsToSpecificUser/{postedToUserId}")]
    [ResponseCache(VaryByHeader = "User-Agent", Duration = 5)]
    public async Task<ActionResult<IReadOnlyList<PostDto>>> GetPostsToSpecificUserAsync(int postedToUserId)
    {
      var allPosts = await _postRepository.ListAllAsync();

      IReadOnlyList<Post> posts = allPosts
      .Where(post => post.PostedToUserId == postedToUserId)
      .OrderByDescending(posts => posts.PostedTime)
      .ToList();

      var postDto = _mapper.Map<List<PostDto>>(posts);

      return postDto;
    }
  }
}