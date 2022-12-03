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
        private readonly IGenericRepository<User> _userRepository;
        private readonly NetworkContext _context;

        public PostController(IGenericRepository<User> userRepository,  NetworkContext context)
        {
            _userRepository = userRepository;
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
    }
}