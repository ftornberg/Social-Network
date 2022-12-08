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
    private readonly IMapper _mapper;

    public PostController(IGenericRepository<Post> postRepository, IMapper mapper)
    {
      _postRepository = postRepository;
      _mapper = mapper;
    }

    [HttpPost("CreatePost")]
    [ResponseCache(VaryByHeader = "User-Agent", Duration = 5)]
    public async Task<ActionResult<PostDto>> CreatePostAsync(PostDto postDto)

    {
      var post = _mapper.Map<Post>(postDto);

      if (post == null) return BadRequest();
      var postCreated = await _postRepository.AddAsync(post);
      var postCreatedDto = _mapper.Map<PostDto>(postCreated);

      return postCreatedDto;
    }

    [HttpGet("GetAllPosts")]
    [ResponseCache(VaryByHeader = "User-Agent", Duration = 5)]
    public async Task<ActionResult<IReadOnlyList<PostDto>>> GetAllPostsAsync()
    {
      var allPosts = await _postRepository.ListAllAsync();

      IReadOnlyList<Post> posts = allPosts
      .OrderByDescending(post => post.PostedTime).ToList();

      var postDto = _mapper.Map<List<PostDto>>(posts);

      return postDto;
    }

    [HttpGet("GetPostsToSpecificUser")]
    [ResponseCache(VaryByHeader = "User-Agent", Duration = 5)]
    public async Task<ActionResult<IReadOnlyList<PostDto>>> GetPostsToSpecificUserAsync(int postedToUserId)
    {
      var allPosts = await _postRepository.ListAllAsync();

      IReadOnlyList<Post> posts = allPosts
      .Where(post => post.PostedToUserId == postedToUserId)
      .OrderBy(posts => posts.PostedTime)
      .ToList();

      var postDto = _mapper.Map<List<PostDto>>(posts);

      return postDto;
    }
  }
}