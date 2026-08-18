using AiSecurityGateway.Core.Models;
using AiSecurityGateway.Security.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace AiSecurityGateway.Api.Controllers;

// Generates test JWT tokens for development.
[ApiController]
[Route("api/[controller]")]
public class TokenController : ControllerBase
{
    private readonly JwtTokenGenerator _tokenGenerator;

    public TokenController(JwtTokenGenerator tokenGenerator)
    {
        _tokenGenerator = tokenGenerator;
    }

    [HttpPost]
    public IActionResult GenerateToken()
    {
        // Temporary identity used for testing authentication flow.
        var identity = new AuthenticatedIdentity
        {
            Id = "user-123",
            Name = "Test User",
            Role = "User"
        };

        // Create a signed JWT token.
        var token = _tokenGenerator.GenerateToken(identity);

        return Ok(new
        {
            Token = token
        });
    }
}