using Test_e.Server.Data;
using Test_e.Server.Helpers;
using Test_e.Server.Models;
using Test_e.Server.Services.IServices;

namespace Test_e.Server.Services
{
    public class DbSeederService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly PasswordService _passwordService;
        private readonly IAuthService _authService;

        public DbSeederService(
            ApplicationDbContext dbContext,
            PasswordService passwordService,
            IAuthService authService)
        {
            _dbContext = dbContext;
            _passwordService = passwordService;
            _authService = authService;
        }

        public async Task SeedSuperAdminAsync()
        {
            // Ensure database is created
            _dbContext.Database.EnsureCreated();

            var superAdminEmail = "superAdmin@gmail.com";
            var superAdminPassword = "superAdminPassword";

            var superAdmin = _dbContext.Users.FirstOrDefault(u => u.Email == superAdminEmail);

            if (superAdmin == null)
            {
                superAdmin = new User
                {
                    FirstName = "Super",
                    LastName = "Admin",
                    Email = superAdminEmail,
                    Password = _passwordService.HashPassword(new User(), superAdminPassword),
                    UserType = UserType.BackOffice
                };

                var allPermsIdsInTheSystem = _dbContext.Permissions.Select(perm => perm.Id).ToList();

                await _authService.AssignPermissionsToUserAsync(allPermsIdsInTheSystem, superAdmin);

                _dbContext.Users.Add(superAdmin);
                _dbContext.SaveChanges();
            }
        }
    }

}
