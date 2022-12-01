using Entity;
using Entity.Interfaces;
using Microsoft.AspNetCore.Mvc;
using API.Dto;
using AutoMapper;
using Infrastructure;
namespace API.Controllers
{
    public class UserController : BaseController
    {
        private readonly IGenericRepository<User> _userRepository;
        private readonly IMapper _mapper;
        private readonly NetworkContext _context;

        public UserController(IGenericRepository<User> userRepository, IMapper mapper, NetworkContext context)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _context = context;
        }

        [HttpPost("register")]
        public async Task<ActionResult<IReadOnlyList<UserRegisterDto>>> RegisterUser(UserRegisterDto registerUserDto)
        {
            User user = new User
            (
              registerUserDto.Name,
              registerUserDto.Email,
              registerUserDto.Password,
              DateTime.Now
            );

            _context.Users?.Add(user);

            var result = await _context.SaveChangesAsync() > 0;

            return result ? Ok() : BadRequest();
        }

        [HttpGet("users")]
        public async Task<ActionResult<IReadOnlyList<UserDto>>> GetUsers()
        {
            var users = await _userRepository.ListAllAsync();

            return Ok(users.Select(user => new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email
            }));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetInfoAboutUserAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);

            return new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
            };
        }

        [HttpDelete("delete")]
        public async Task<ActionResult<bool>> DeleteUserAsync(string email, string password)
        {
            var user = await ValidateUserAsync(email, password);

            await _userRepository.DeleteAsync(user.Value);

            return true;
        }

        [HttpPut("update")]
        public async Task<ActionResult<User>> UpdateUserAsync(UserUpdateDto userUpdateDto)
        {
            var user = await ValidateUserAsync(userUpdateDto.Email, userUpdateDto.Password);

            if (user.Value.Name == userUpdateDto.OldProperty)
                user.Value.Name = userUpdateDto.UpdatedProperty;

            if (user.Value.Email == userUpdateDto.OldProperty)
                user.Value.Email = userUpdateDto.UpdatedProperty;

            if (user.Value.Password == userUpdateDto.OldProperty)
                user.Value.Password = userUpdateDto.UpdatedProperty;

            _context.Users?.Update(user.Value);
            var result = await _context.SaveChangesAsync() > 0;

            return result ? Ok() : BadRequest();
        }

        private async Task<ActionResult<User>> ValidateUserAsync(string email, string password)
        {
            var user = await GetUserByEmailAsync(email);

            if (user?.Value?.Password != password) return BadRequest();
            var entity = await _userRepository.GetByIdAsync(user.Value.Id);

            return entity;
        }

        private async Task<ActionResult<UserDto>?> GetUserByEmailAsync(string email)
        {
            var users = await _userRepository.ListAllAsync();
            try
            {
                var user = users.FirstOrDefault(u => u.Email == email);
                UserDto userDto = new UserDto { Email = user.Email, Password = user.Password, Name = user.Name, Id = user.Id };
                return userDto;
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}