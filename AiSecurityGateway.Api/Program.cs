using AiSecurityGateway.Core.Interfaces;
using AiSecurityGateway.Security.Authentication;
using AiSecurityGateway.Security.Authorization;
using AiSecurityGateway.Infrastructure.Logging;

var builder = WebApplication.CreateBuilder(args);

// Load JWT configuration from appsettings.json.
builder.Services.Configure<JwtSettings>(
    builder.Configuration.GetSection("JwtSettings"));

// Register security services.
builder.Services.AddScoped<ITokenValidator, JwtValidator>();
builder.Services.AddScoped<AuthenticationService>();
builder.Services.AddScoped<JwtTokenGenerator>();
builder.Services.AddScoped<AuthorizationService>();
builder.Services.AddScoped<PolicyEngine>();
builder.Services.AddScoped<IAuditLogger, AuditLogger>();

// Register controllers.
builder.Services.AddControllers();

builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

// Enable controller endpoints.
app.MapControllers();

app.Run();