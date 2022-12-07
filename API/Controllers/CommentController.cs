using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dto;
using AutoMapper;
using Entity;
using Entity.Interfaces;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class CommentController : BaseController
    {
        private readonly IGenericRepository<Comment> _commentRepository;
        private readonly IMapper _mapper;

        public CommentController(IGenericRepository<Comment> commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
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

            if (comment == null) return BadRequest();
            _commentRepository.AddAsync(comment);

            return Ok();
        }

        [HttpGet("GetComments")]

        public async Task<List<CommentDto>> GetComments()
        {
            var comments = await _commentRepository.ListAllAsync();
            var commentDto = _mapper.Map<List<CommentDto>>(comments);

            return commentDto;
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<CommentDto>> GetCommentById(int id)
        {
            var comment = await _commentRepository.GetByIdAsync(id);
            var commentDto = _mapper.Map<CommentDto>(comment);

            return commentDto;
        }

        /*[HttpDelete("DeleteComment")]
        public async Task<ActionResult<bool>> DeleteCommentAsync(int commentId, int CommentedByUserId)
        {
            var comment = await _commentRepository.GetByIdAsync(commentId);

            if (CommentedByUserId != comment.CommentedByUserId) return BadRequest();
            await _commentRepository.DeleteAsync(comment);
            return Ok();
        }

        [HttpPut("UpdateComment")]

        public async Task<ActionResult<Comment>> UpdateCommentAsync(CommentDto commentDto, int userId)
        {
            var comment = await _commentRepository.GetByIdAsync(commentDto.PostId);

            if (comment.CommentedByUserId != userId) return BadRequest();
            comment.Message = commentDto.Message;

            _context.Comments?.Update(comment);
            var result = await _context.SaveChangesAsync() > 0;

            return result ? Ok() : BadRequest();
        }*/
    }
}