using API.Dto;
using AutoMapper;
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
    private readonly IMapper _mapper;

    public PostController(IGenericRepository<Post> postRepository, IMapper mapper)
    {
      _postRepository = postRepository;
      _mapper = mapper;
    }

    [HttpPost("CreatePost")]
    [ResponseCache(VaryByHeader = "User-Agent", Duration = 5)]
    public async Task<ActionResult<Post>> CreatePostAsync(PostDto postDto)

    {
      Post post = new Post
      (
          postDto.PostedMessage,
          postDto.PostedByUserId,
          postDto.PostedToUserId,
          DateTime.Now
      );

      if (post.Id == null) return BadRequest();
      var result = await _postRepository.AddAsync(post);

      return Ok(result);
    }

    [HttpGet("GetAllPosts")]
    [ResponseCache(VaryByHeader = "User-Agent", Duration = 5)]
    public async Task<ActionResult<IReadOnlyList<PostDto>>> GetAllPostsAsync()
    {
      var allPosts = await _postRepository.ListAllAsync();
      var postDto = _mapper.Map<List<PostDto>>(allPosts);

      return Ok(postDto);
    }


    [HttpGet("GetPostsToSpecificUser")]
    [ResponseCache(VaryByHeader = "User-Agent", Duration = 5)]
    public async Task<ActionResult<IReadOnlyList<PostDto>>> GetPostsToSpecificUserAsync(int postedToUserId)
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