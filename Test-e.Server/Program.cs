using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Test_e.Server.AppSettings;
using Test_e.Server.Data;
using Test_e.Server.Extensions;
using Test_e.Server.Helpers;
using Test_e.Server.Middlewares;
using Test_e.Server.Repositories;
using Test_e.Server.Services;
using Test_e.Server.Services.IServices;

var builder = WebApplication.CreateBuilder(args);
// -----------------------------------------------------------------------------
// AppSettings
// -----------------------------------------------------------------------------
builder.Services.Configure<JWTSettings>(builder.Configuration.GetSection("Jwt"));
builder.Services.Configure<ConnectionStringsSettings>(
    builder.Configuration.GetSection("ConnectionSettings"));

// -----------------------------------------------------------------------------
// Controller and Swagger Services
// -----------------------------------------------------------------------------
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerWithJwt();

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

// -----------------------------------------------------------------------------
// Configure JWT
// -----------------------------------------------------------------------------
builder.Services.AddJwtAuthentication(builder.Configuration);

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
builder.Services.AddScoped<ICustomerAuthService, CustomerAuthService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<DbSeederService>();
builder.Services.AddScoped<IProductService,ProductService>();
builder.Services.AddSingleton<PasswordService>();
builder.Services.AddSingleton<Helper>();

// -----------------------------------------------------------------------------
// Handle model validation errors uniformly
// -----------------------------------------------------------------------------
builder.Services.ConfigureModelBindingValidationResponse();
// -----------------------------------------------------------------------------


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
    var dBSeederService = scope.ServiceProvider.GetRequiredService<DbSeederService>();
    await dBSeederService.SeedSuperAdminAsync();

}

app.Run();
