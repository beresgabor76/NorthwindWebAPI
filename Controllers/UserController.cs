using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NwOrdersAPI.DTOs;
using NwOrdersAPI.Entities;
using NwOrdersAPI.Interface;
using System.Security.Cryptography;
using System.Text;

namespace NwOrdersAPI.Controllers
{
    [ApiController]
    [Route("nwapi/[controller]")]
    public class UserController : Controller
    {
        private NwDbContext _context;
        private ITokenService _tokenService;
        public UserController(NwDbContext context, ITokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserTokenDto>> RegisterUser([FromBody] RegisterUserDto dto)
        {
            using HMACSHA512 hmac = new HMACSHA512();
            byte[] passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(dto.Password));
            byte[] passwordSalt = hmac.Key;

            await _context.CreateUserAsync(dto.Username.ToLower(), passwordHash, passwordSalt);

            return new UserTokenDto
            {
                Username = dto.Username,
                Token = _tokenService.CreateToken(dto.Username)
            };
        }

        [Authorize]
        [HttpGet("{username}")]
        public async Task<ActionResult<User>> GetUser(string username)
        { 
            var user = await _context.SelectUserAsync(username);
            if (user == null)
                return NotFound("User not found.");
            else
                return user;
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserTokenDto>> LoginUser(RegisterUserDto dto)
        { 
            User user = await _context.SelectUserAsync(dto.Username);
            if (user == null)
            {
                return BadRequest("Bad username");
            }
            else
            {
                using HMACSHA512 hmac = new HMACSHA512(user.PasswordSalt);
                byte[] computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(dto.Password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != user.PasswordHash[i])
                        return BadRequest("Bad password");
                }
                return new UserTokenDto
                {
                    Username = user.Username,
                    Token = _tokenService.CreateToken(user.Username)
                };
            }
        }


    }
}
