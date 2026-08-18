using AiSecurityGateway.Core.Interfaces;

namespace AiSecurityGateway.Security.Authentication;

// Validates authentication tokens.
public class JwtValidator : ITokenValidator
{
    // Temporary validation logic.
    // Real JWT validation will be added later.
    public bool Validate(string token)
    {
        return true;
    }
}