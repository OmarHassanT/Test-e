using Microsoft.EntityFrameworkCore;
using System.Security;
using Test_e.Server.Data;
using Test_e.Server.DTOs;
using Test_e.Server.Exceptions;
using Test_e.Server.Helpers;
using Test_e.Server.Models;
using Test_e.Server.Services.IServices;

namespace Test_e.Server.Services
{
    public class CustomerAuthService : ICustomerAuthService
    {
        private readonly ApplicationDbContext _db;
        private readonly ITokenService _tokenService;
        private readonly PasswordService _passwordService;

        public CustomerAuthService(ApplicationDbContext db,
            ITokenService tokenService,
            PasswordService passwordService)
        {
            _db = db;
            _tokenService = tokenService;
            _passwordService = passwordService;
        }

        public async Task<string> RegisterCustomerAsync(RegisterCustomerDto registerCustomerDto)
        {
            bool isPhoneNumberTaken = await _db.Users.AnyAsync(u => u.Phone == registerCustomerDto.Phone);
            if (isPhoneNumberTaken)
                throw new ConflictException("Phone Number already Taken.");

            var hashedPassword = _passwordService.HashPassword(new User(), registerCustomerDto.Password);

            var user = new User
            {
                FirstName = registerCustomerDto.FirstName,
                LastName = registerCustomerDto.LastName,
                Phone = registerCustomerDto.Phone,
                Password = hashedPassword,
                UserType = UserType.Customer
            };

            await AssignCustomerPermissionsAsync(user);

            _db.Users.Add(user);
            var token = _tokenService.CreateToken(user);

            await _db.SaveChangesAsync();

            return token;
        }

        private async Task AssignCustomerPermissionsAsync(User user)
        {
            const int PRODUCT_PERMISSON_ID = 8;//Products
            var permissions = new List<UserPermission>();

            List<int> permissionIds = [PRODUCT_PERMISSON_ID,]; //You can add more permission IDs here for the customer

            foreach (var permissionId in permissionIds)
            {
                var permission = await _db.Permissions.FindAsync(permissionId) ?? throw new NotFoundException($"No Permission with id={permissionId}");

                permissions.Add(new UserPermission
                {
                    Permission = permission,
                    PermissionId = permission.Id,
                    UserId = user.Id,
                    User = user
                });
            }

            user.UserPermissions = permissions;
        }

        public async Task<string> LoginCustomerAsync(string phone, string password)
        {
            var user = await _db.Users
                .Include(user => user.UserPermissions)
                .ThenInclude(up => up.Permission)
                .FirstOrDefaultAsync(u => u.Phone == phone);

            if (user == null || !_passwordService.VerifyPassword(user, password, user.Password))
                throw new ArgumentException("Invalid credentials.");

            var token = _tokenService.CreateToken(user);
            return token;
        }

    }
}
