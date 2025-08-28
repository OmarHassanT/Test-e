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

        public async Task<string> RegisterAsync(RegisterUserDto registerUserDto)
        {
            bool isEmailTaken = await _db.Users.AnyAsync(u => u.Email == registerUserDto.Email);
            if (isEmailTaken)
                throw new ConflictException("Email already Taken.");

            var hashedPassword = _passwordService.HashPassword(new User(), registerUserDto.Password);
            var user = new User
            {
                FirstName = registerUserDto.FirstName,
                LastName = registerUserDto.LastName,
                Email = registerUserDto.Email,
                Password = hashedPassword,
                UserType = UserType.BackOffice
            };

            bool isIncomingPermissionsNotNullOrEmpty = registerUserDto.PermissionIds != null &&
                                                    registerUserDto.PermissionIds.Any();

            if (isIncomingPermissionsNotNullOrEmpty)
            {
                await AssignPermissionsToUserAsync(registerUserDto.PermissionIds!, user);
            }
            else
            {
                AssignBackOfficeDefaultPermissions(user);
            }

            _db.Users.Add(user);
            var token = _tokenService.CreateToken(user);

            await _db.SaveChangesAsync();

            return token;
        }

        public async Task<string> LoginAsync(string email, string password)
        {
            var user = await _db.Users
                .Include(u => u.UserPermissions)
                .ThenInclude(up => up.Permission)
                .FirstOrDefaultAsync(u => u.Email == email);
            if (user == null || !_passwordService.VerifyPassword(user, password, user.Password))
                throw new ArgumentException("Invalid credentials.");

            var token = _tokenService.CreateToken(user);
            return token;
        }

        /// <summary>
        /// Assign Permissions To BackOffice Users 
        /// </summary>
        /// <param name="permissionIds"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        /// <exception cref="NotFoundException"></exception>
        public async Task AssignPermissionsToUserAsync(List<int> permissionIds, User user)
        {
            var permissions = new List<UserPermission>();

            foreach (var pId in permissionIds)
            {
                var permission = await _db.Permissions.FindAsync(pId) ?? throw new NotFoundException($"No Permission with id={pId}");
               
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

        private static void AssignBackOfficeDefaultPermissions(User user)
        {
            // assign default permission(s)
            user.UserPermissions.Add(new UserPermission
            {
                PermissionId = 1, // e.g. Dashboard.View
                User = user
            });
        }




    }
}
