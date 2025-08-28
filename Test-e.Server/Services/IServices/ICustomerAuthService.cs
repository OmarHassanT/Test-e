using Test_e.Server.DTOs;
using Test_e.Server.Models;

namespace Test_e.Server.Services.IServices
{
    public interface ICustomerAuthService
    {
        Task<string> RegisterCustomerAsync(RegisterCustomerDto dto);
        Task<string> LoginCustomerAsync(string phone, string password);
    }
}
