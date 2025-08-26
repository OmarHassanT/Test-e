using Microsoft.AspNetCore.Mvc;
using System;
using System.Text;
using Test_e.Server.Data;
using Test_e.Server.Models;
using Test_e.Server.Services;

namespace Test_e.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public record LoginDto(string Email, string Password);

    public class AuthController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        private readonly ITokenService _tokenService;

        public AuthController(ApplicationDbContext db, ITokenService tokenService)
        {
            _db = db;
            _tokenService = tokenService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] User userDto)
        {
            if (await _db.Users.AnyAsync(u => u.Email == userDto.Email))
                return BadRequest("Email already in use.");

            var hashedPassword = HashPassword(userDto.Password);
            var user = new User
            {
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Email = userDto.Email,
                Password = hashedPassword,
                Role = string.IsNullOrEmpty(userDto.Role) ? "Customer" : userDto.Role
            };

            _db.Users.Add(user);
            await _db.SaveChangesAsync();

            var token = _tokenService.CreateToken(user);
            return Ok(new { token });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            var user = await _db.Users.FirstOrDefaultAsync(u => u.Email == dto.Email);
            if (user == null || !VerifyPassword(dto.Password, user.Password))
                return Unauthorized("Invalid credentials.");

            var token = _tokenService.CreateToken(user);
            return Ok(new { token });
        }

        // Simple SHA256 hashing (for demo — use a proper password hasher in prod!)
        private static string HashPassword(string password)
        {
            using var sha = SHA256.Create();
            var bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(bytes);
        }

        private static bool VerifyPassword(string password, string hashed)
            => HashPassword(password) == hashed;
    }
}
