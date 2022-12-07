using Entity;
using Entity.Interfaces;
using Microsoft.AspNetCore.Mvc;
using API.Dto;
using AutoMapper;
using Infrastructure;

namespace API.Controllers
{
    public class DirectMessageController : BaseController
    {
        private readonly IGenericRepository<DirectMessage> _directMessageRepository;
        private readonly IMapper _mapper;
        private readonly NetworkContext _context;

        public DirectMessageController(IGenericRepository<DirectMessage> directMessageRepository, IMapper mapper, NetworkContext context)
        {
            _directMessageRepository = directMessageRepository;
            _mapper = mapper;
            _context = context;
        }

        [HttpPost("SendMessage")]
        public async Task<ActionResult<IReadOnlyList<DirectMessageDto>>> SendMessage(DirectMessageDto directMessageDto)
        {
            DirectMessage directMessage = new DirectMessage
            (
                directMessageDto.Sender,
                directMessageDto.Receiver,
                directMessageDto.Message,
                DateTime.Now
            );

            _context.DirectMessages?.Add(directMessage);

            var result = await _context.SaveChangesAsync() > 0;

            return result ? Ok() : BadRequest();
        }

        [HttpGet("GetMessages")]
        public async Task<ActionResult<IReadOnlyList<DirectMessage>>> GetMessages(int sender, int receiver)
        {
            var directMessages = await _directMessageRepository.ListAllAsync();
            IReadOnlyList<DirectMessage> messages = directMessages
            .Where(message => (message.Sender == sender && message.Receiver == receiver) || (message.Sender == receiver && message.Receiver == sender))
            .OrderByDescending(message => message.TimeSent).ToList();
            
            return Ok(messages);
        }

        // [HttpDelete("delete")]
        // public async Task<ActionResult<bool>> DeleteUserAsync(int messageId)
        // {
        //     var message = await GetMessageByIdAsync(messageId);

        //     await _directMessageRepository.DeleteAsync(message.Value);

        //     return true;
        // }

        // private async Task<ActionResult<DirectMessage>?> GetMessageByIdAsync(int id)
        // {
        //     var directMessages = await _directMessageRepository.ListAllAsync();
        //     try
        //     {
        //         var message = directMessages.FirstOrDefault(p => p.Id == id);
        //         return message;
        //     }
        //     catch (Exception)
        //     {
        //         return BadRequest();
        //     }
        // }

    }
}