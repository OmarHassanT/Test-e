using Test_e.Server.DTOs;
using Test_e.Server.Models;

namespace Test_e.Server.Services.IServices
{
    public interface IAuthService
    {
        Task<string> RegisterAsync(RegisterUserDto dto);
        Task<string> LoginAsync(string email, string password);
        Task AssignPermissionsToUserAsync(List<int> permissionIds, User user);

    }
}
