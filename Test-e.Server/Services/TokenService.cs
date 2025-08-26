using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Test_e.Server.AppSettings;
using Test_e.Server.Models;
using Test_e.Server.Services.IServices;
using Test_e.Server.Helpers;
namespace Test_e.Server.Services
{
    public class TokenService : ITokenService
    {
        private readonly JWTSettings _jwt;
        private readonly Helper _helper;

        public TokenService(IOptions<JWTSettings> jwtOptions,
             Helper helper)
        {
            _jwt = jwtOptions.Value;
            _helper = helper;
        }

        public string CreateToken(User user)
        {
            _helper.ValidateConfig(_jwt.Key, "jwt.Key");
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new(JwtRegisteredClaimNames.UniqueName, user.FullName),
            new(JwtRegisteredClaimNames.Email, user.Email ?? ""),
            new(ClaimTypes.Role, user.Role) // 🔑 role comes from your User.Role field
        };

            var token = new JwtSecurityToken(
                issuer: _jwt.Issuer,
                audience: _jwt.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwt.ExpiresMinutes ?? 100),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
