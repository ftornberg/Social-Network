using API.Dto;
using AutoMapper;
using Entity;
using Entity.Interfaces;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class PostController : BaseController
    {
        private readonly IGenericRepository<Post> _postRepository;
        private readonly NetworkContext _context;

        public PostController(IGenericRepository<Post> postRepository, NetworkContext context)
        {
            _postRepository = postRepository;
            _context = context;
        }

        [HttpPost("post")]
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

        [HttpGet("posts")]
        public async Task<ActionResult<IReadOnlyList<PostDto>>> GetPosts()
        {
            var posts = await _postRepository.ListAllAsync();

            return Ok(posts.Select(post => new PostDto
            {
                Id = post.Id,
                PostedMessage = post.PostedMessage,
                PostedByUserId = post.PostedByUserId,
                PostedToUserId = post.PostedToUserId,
                PostedTime = post.PostedTime
            }));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PostDto>> GetPostByIdAsync(int id)
        {
            var post = await _postRepository.GetByIdAsync(id);

            return new PostDto
            {
                Id = post.Id,
                PostedMessage = post.PostedMessage,
                PostedByUserId = post.PostedByUserId,
                PostedToUserId = post.PostedToUserId,
                PostedTime = post.PostedTime
            };
        }
    }
}