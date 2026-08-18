using AiSecurityGateway.Core.Interfaces;
using AiSecurityGateway.Security.Authentication;

var builder = WebApplication.CreateBuilder(args);

// Register security services
builder.Services.AddScoped<ITokenValidator, JwtValidator>();
builder.Services.AddScoped<AuthenticationService>();

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