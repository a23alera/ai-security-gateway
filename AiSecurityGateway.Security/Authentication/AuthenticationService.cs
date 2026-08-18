using AiSecurityGateway.Core.Interfaces;
using AiSecurityGateway.Core.Models;

namespace AiSecurityGateway.Security.Authentication;

// Handles token validation and creates an authenticated identity.
public class AuthenticationService
{
    private readonly ITokenValidator _tokenValidator;

    public AuthenticationService(ITokenValidator tokenValidator)
    {
        _tokenValidator = tokenValidator;
    }

    public AuthenticatedIdentity? Authenticate(string token)
    {
        // Validate token and return identity information.
        return _tokenValidator.Validate(token);
    }
}