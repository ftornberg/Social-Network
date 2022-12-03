using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dto;
using Entity;
using Entity.Interfaces;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class CommentController : BaseController
    {
        private readonly IGenericRepository<Comment> _commentRepository;

        private readonly NetworkContext _context;

        public CommentController(IGenericRepository<Comment> commentRepository, NetworkContext context)
        {
            _commentRepository = commentRepository;
            _context = context;
        }

        [HttpPost("PostComment")]

        public async Task<ActionResult<CommentDto>> PostComment(CommentDto commentDto)
        {
            Comment comment = new Comment
            (
                commentDto.PostId,
                commentDto.CommentedByUserId,
                commentDto.Message,
                DateTime.Now
            );

            _context.Comments.Add(comment);

            var result = await _context.SaveChangesAsync() > 0;

            return result ? Ok() : BadRequest();

        }

        [HttpGet("{id}")]

        public async Task<ActionResult<CommentDto>> GetCommentById(int id)
        {
            var comment = await _commentRepository.GetByIdAsync(id);

            return new CommentDto
            {
                PostId = comment.PostId,
                CommentedByUserId = comment.CommentedByUserId,
                Message = comment.Message,
                CommentedTime = comment.CommentedTime
            };
        }
    }
}