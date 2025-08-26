using Test_e.Server.DTOs;

namespace Test_e.Server.Services.IServices
{
    public interface IAuthService
    {
        Task<string> RegisterAsync(RegisterUserDto dto);
        Task<string> LoginAsync(string email, string password);
    }
}
