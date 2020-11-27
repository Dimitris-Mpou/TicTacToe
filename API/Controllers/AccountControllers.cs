using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class AccountController : BaseController
    {
        private readonly DataContex _context;
        private readonly ITokenService _tokenService;
        public AccountController(DataContex context, ITokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto) {
            if (await UserExists(registerDto.Username)) return BadRequest("This Username is taken");

            using var hmac = new HMACSHA512();
            var user = new User
            {
                UserName = registerDto.Username.ToLower(),
                KnownAs = registerDto.KnownAs,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
                PasswordSalt = hmac.Key
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return new UserDto
            {
                Username = user.UserName,
                KnownAs = user.KnownAs,
                Token = _tokenService.CreateToken(user)
            };
        }

        private async Task<bool> UserExists(string username)
        {
            return await _context.Users.AnyAsync(x => x.UserName == username.ToLower());
        }


        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            
            var user =  await _context.Users.SingleOrDefaultAsync(x => x.UserName == loginDto.Username.ToLower());

            if (user == null) return BadRequest("Invalid Name");

            using var hmac = new HMACSHA512(user.PasswordSalt);
            var  PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

            for(int i = 0; i<PasswordHash.Length; i++)
            {
                if (PasswordHash[i] != user.PasswordHash[i]) return Unauthorized("Wrong Password");
            }


            return new UserDto
            {
                Username = user.UserName,
                KnownAs = user.KnownAs,
                Token = _tokenService.CreateToken(user)
            };
        }   
    }
}