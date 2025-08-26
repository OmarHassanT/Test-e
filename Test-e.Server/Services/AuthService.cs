using Microsoft.EntityFrameworkCore;
using Test_e.Server.Data;
using Test_e.Server.DTOs;
using Test_e.Server.Exceptions;
using Test_e.Server.Helpers;
using Test_e.Server.Models;
using Test_e.Server.Services.IServices;

namespace Test_e.Server.Services
{
    public class AuthService : IAuthService
    {
        private readonly ApplicationDbContext _db;
        private readonly ITokenService _tokenService;
        private readonly PasswordService _passwordService;

        public AuthService(ApplicationDbContext db,
            ITokenService tokenService,
            PasswordService passwordService)
        {
            _db = db;
            _tokenService = tokenService;
            _passwordService = passwordService;
        }

        public async Task<string> RegisterAsync(RegisterUserDto dto)
        {
            if (await _db.Users.AnyAsync(u => u.Email == dto.Email))
                throw new ConflictException("Email already Taken.");
            var hashedPassword = _passwordService.HashPassword(new User(), dto.Password);
            var user = new User
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                Password = hashedPassword,
                Role = string.IsNullOrEmpty(dto.Role) ? "Customer" : dto.Role
            };

            _db.Users.Add(user);
            await _db.SaveChangesAsync();

            var token = _tokenService.CreateToken(user);
            return token;
        }

        public async Task<string> LoginAsync(string email, string password)
        {
            var user = await _db.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (user == null || !_passwordService.VerifyPassword(user, password, user.Password))
                throw new ArgumentException("Invalid credentials.");

            var token = _tokenService.CreateToken(user);
            return token;
        }
    }
}
