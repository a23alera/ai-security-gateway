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

    // Returns an identity if the token is valid.
    public AuthenticatedIdentity? Authenticate(string token)
    {
        // Stop the request if token validation fails.
        if (!_tokenValidator.Validate(token))
        {
            return null;
        }

        // Temporary identity. Will later come from token claims or identity provider.
        return new AuthenticatedIdentity
        {
            Id = "test-id",
            Name = "Test User",
            Role = "User"
        };
    }
}