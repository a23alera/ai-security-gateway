using AiSecurityGateway.Security.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace AiSecurityGateway.Api.Controllers;

// Handles authentication requests and delegates security logic.
[ApiController]
[Route("api/[controller]")]
public class AuthenticationController : ControllerBase
{
    private readonly AuthenticationService _authenticationService;

    // Inject authentication service through dependency injection.
    public AuthenticationController(AuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [HttpPost]
    public IActionResult Authenticate()
    {
        // Get JWT token from Authorization header.
        var authHeader = Request.Headers.Authorization.ToString();

        if (string.IsNullOrEmpty(authHeader))
        {
            return Unauthorized("Missing authorization header.");
        }

        // Remove Bearer prefix before validation.
        var token = authHeader.Replace("Bearer ", "");

        // Validate token through security layer.
        var identity = _authenticationService.Authenticate(token);

        if (identity == null)
        {
            return Unauthorized("Invalid token.");
        }

        return Ok(identity);
    }
}