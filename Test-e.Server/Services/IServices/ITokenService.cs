using Test_e.Server.Models;

namespace Test_e.Server.Services.IServices
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }

}
