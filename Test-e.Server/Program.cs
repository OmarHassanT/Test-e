using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Security.Claims;
using System.Text;
using Test_e.Server.AppSettings;
using Test_e.Server.Data;
using Test_e.Server.Helpers;
using Test_e.Server.Middlewares;
using Test_e.Server.Models;
using Test_e.Server.Repositories;
using Test_e.Server.Services;
using Test_e.Server.Services.IServices;

var builder = WebApplication.CreateBuilder(args);
// -----------------------------------------------------------------------------
// AppSettings
// -----------------------------------------------------------------------------

builder.Services.Configure<ConnectionStringsSettings>(
    builder.Configuration.GetSection("ConnectionSettings"));

// -----------------------------------------------------------------------------
// Controller and Swagger Services
// -----------------------------------------------------------------------------
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });

    // Define the security scheme
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Enter 'Bearer' [space] and then your token.\nExample: \"Bearer eyJhbGciOiJIUzI1NiIs...\""
    });

    // Apply security to all endpoints
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});
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

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
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
            ClockSkew = TimeSpan.Zero,
            RoleClaimType = ClaimTypes.Role // ✅ tells ASP.NET Core to use this claim for [Authorize(Roles=...)]

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
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddSingleton<PasswordService>();
builder.Services.AddSingleton<Helper>();



var app = builder.Build();
app.UseMiddleware<ExceptionHandlingMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    });
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
    var passwordService = scope.ServiceProvider.GetRequiredService<PasswordService>();

    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<AppRole>>();
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();

    var rolesSupported = new[] { "SuperAdmin", "Admin", "Customer", "Employee", "Trader" };
   
    var superAdminEmail = "superAdmin@gmail.com";
    var superAdminPassword = "superAdminPassword";

    var superAdmin = context.Users.FirstOrDefault(u => u.Email == superAdminEmail);
    if (superAdmin == null)
    {
        superAdmin = new User
        {
            FirstName = "Super",
            LastName = "Admin",
            Email = superAdminEmail,
            Password = passwordService.HashPassword(new User(), superAdminPassword),
            Role = "SuperAdmin"
        };

        context.Users.Add(superAdmin);
        context.SaveChanges();
    }
}

app.Run();
