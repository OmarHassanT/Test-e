using Microsoft.AspNetCore.Identity;
using Test_e.Server.Models;

namespace Test_e.Server.Helpers
{
    public class PasswordService
    {
        private readonly PasswordHasher<User> _hasher = new();

        // Hash password securely
        public string HashPassword(User user, string password)
        {
            return _hasher.HashPassword(user, password);
        }

        // Verify hashed password
        public bool VerifyPassword(User user, string password, string hashedPassword)
        {
            var result = _hasher.VerifyHashedPassword(user, hashedPassword, password);
            return result == PasswordVerificationResult.Success;
        }
    }
}
