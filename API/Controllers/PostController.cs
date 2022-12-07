using API.Dto;
using Entity;
using Entity.Interfaces;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using AutoMapper;
namespace API.Controllers
{
  public class PostController : BaseController
  {
    private readonly IGenericRepository<Post> _postRepository;
    private readonly NetworkContext _context;
    private readonly IMapper _mapper;

    public PostController(IGenericRepository<Post> postRepository, NetworkContext context, IMapper mapper)
    {
      _postRepository = postRepository;
      _context = context;
      _mapper = mapper;
    }

    [HttpPost("createpost")]
    public async Task<ActionResult<IReadOnlyList<PostDto>>> Post(PostDto postDto)
    {
      Post post = new Post
      (
          postDto.PostedMessage,
          postDto.PostedByUserId,
          postDto.PostedToUserId,
          DateTime.Now
      );

      _context.Posts?.Add(post);

      var result = await _context.SaveChangesAsync() > 0;

      return result ? Ok() : BadRequest();
    }

    [HttpGet("getposts")]
    [ResponseCache(VaryByHeader = "User-Agent", Duration = 5)]
    public async Task<ActionResult<IReadOnlyList<PostDto>>> GetPosts(int postedToUserId)
    {

      var allPosts = await _postRepository.ListAllAsync();

      IReadOnlyList<Post> posts = allPosts
      .Where(posts => posts.PostedToUserId == postedToUserId)
      .OrderByDescending(posts => posts.PostedTime).ToList();

      var postDto = _mapper.Map<List<PostDto>>(posts);

      return Ok(postDto);
    }

    // [HttpGet("{id}")]
    // public async Task<ActionResult<PostDto>> GetPostByIdAsync(int id)
    // {
    //     var post = await _postRepository.GetByIdAsync(id);

    //     return new PostDto
    //     {
    //         Id = post.Id,
    //         PostedMessage = post.PostedMessage,
    //         PostedByUserId = post.PostedByUserId,
    //         PostedToUserId = post.PostedToUserId,
    //         PostedTime = post.PostedTime
    //     };
    // }

    // [HttpDelete("deletePost")]
    // public async Task<ActionResult<bool>> DeletePostAsync(int postId, int postedByUserId)
    // {
    //     var post = await _postRepository.GetByIdAsync(postId);

    //     if (postedByUserId != post.PostedByUserId) return BadRequest();
    //     await _postRepository.DeleteAsync(post);
    //     return Ok();
    // }


    // Ej klar än, får BadRequest();
    // [HttpPut("updatePost")]
    // public async Task<ActionResult<Post>> UpdatePostAsync(PostDto postDto)
    // {
    //     var post = await _postRepository.GetByIdAsync(postDto.PostedByUserId);

    //     if (post.PostedByUserId != postDto.PostedByUserId) return BadRequest();
    //     post.PostedMessage = postDto.PostedMessage;

    //     _context.Posts?.Update(post);
    //     var result = await _context.SaveChangesAsync() > 0;

    //     return result ? Ok() : BadRequest();
    // }
  }
}