using API.Dto.Comment;

namespace API.Controllers;

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
    public async Task<ActionResult<CommentDto>> PostCommentAsync(CommentDto commentDto)
    {
        var comment = _mapper.Map<Comment>(commentDto);

        if (comment == null) return BadRequest();
        var commentCreated = await _commentRepository.AddAsync(comment);
        var commentCreatedDto = _mapper.Map<CommentDto>(commentCreated);

        return commentCreatedDto;
    }

    [HttpGet("GetComments")]
    public async Task<List<CommentDto>> GetCommentsAsync()
    {
        var comments = await _commentRepository.ListAllAsync();
        var commentDto = _mapper.Map<List<CommentDto>>(comments);

        return commentDto;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CommentDto>> GetCommentByIdAsync(int id)
    {
        var comment = await _commentRepository.GetByIdAsync(id);
        var commentDto = _mapper.Map<CommentDto>(comment);

        return commentDto;
    }
}
