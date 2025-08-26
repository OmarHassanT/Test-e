using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Test_e.Server.AppSettings;
using Test_e.Server.Data;
using Test_e.Server.Repositories;

var builder = WebApplication.CreateBuilder(args);

// -----------------------------------------------------------------------------
// Controller and Swagger Services
// -----------------------------------------------------------------------------
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// -----------------------------------------------------------------------------
// Database Configuration
// -----------------------------------------------------------------------------
builder.Services.AddDbContext<ApplicationDbContext>((serviceProvider, options) =>
{
    var env = serviceProvider.GetRequiredService<IWebHostEnvironment>();

    if (env.IsEnvironment("Testing"))
    {
        // Do not register SQL Server in test environment � test project will override this
        return;
    }

    // Only register SQL Server in dev/staging/prod
    var connectionOptions = serviceProvider
        .GetRequiredService<IOptions<ConnectionStringsSettings>>().Value;

    options.UseSqlServer(connectionOptions.RemoteConnection);
});
//

//////////
builder.Services
    .AddIdentity<AppUser, AppRole>(options =>
    {
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireUppercase = false;
        options.Password.RequireDigit = false;
        options.Password.RequiredLength = 6;
    })
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

// -----------------------------------------------------------------------------
// Configure JWT
// -----------------------------------------------------------------------------
builder.Services.Configure<JWTSettings>(builder.Configuration.GetSection("Jwt"));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        var jwtSettings = builder.Configuration.GetSection("Jwt").Get<JWTSettings>()!;

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Key));

        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = jwtSettings.Issuer,
            ValidateAudience = true,
            ValidAudience = jwtSettings.Audience,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = key,
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero
        };
    });

//
// -----------------------------------------------------------------------------
// CORS Configuration
// -----------------------------------------------------------------------------
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyMethod()
                  .AllowAnyHeader();
        });
});

// -----------------------------------------------------------------------------
// Dependency Injection - Application Services
// -----------------------------------------------------------------------------
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseDefaultFiles();
app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseCors("AllowAll");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

// Ensure database is created
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    context.Database.EnsureCreated();

    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<AppRole>>();
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();

    var rolesSupported = new[] { "SuperAdmin", "Admin", "Customer", "Employee", "Trader" };
    foreach (var role in rolesSupported)
    {
        if (!await roleManager.RoleExistsAsync(role))
            await roleManager.CreateAsync(new AppRole { Name = role });
    }

    var superAdminEmail = "superAdmin@gmail.com";
    var superAdminPassword = "superAdminPassword";

    var superAdmin = await userManager.FindByEmailAsync(superAdminEmail);
    if (superAdmin == null)
    {
        superAdmin = new AppUser { UserName = "SuperAdmin", Email = superAdminEmail, EmailConfirmed = true };
        await userManager.CreateAsync(superAdmin, superAdminPassword);

        await userManager.AddToRoleAsync(superAdmin, "SuperAdmin");
    }
}

app.Run();
