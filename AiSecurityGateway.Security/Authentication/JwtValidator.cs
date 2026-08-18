using AiSecurityGateway.Core.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using AiSecurityGateway.Core.Models;
using System.Security.Claims;

namespace AiSecurityGateway.Security.Authentication;

// Validates authentication tokens.
public class JwtValidator : ITokenValidator
{
    private readonly JwtSettings _jwtSettings;

    public JwtValidator(IOptions<JwtSettings> jwtSettings)
    {
        _jwtSettings = jwtSettings.Value;
    }

    public AuthenticatedIdentity? Validate(string token)
    {
        // Defines the rules used when validating the JWT token.
        var validationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = _jwtSettings.Issuer,

            ValidateAudience = true,
            ValidAudience = _jwtSettings.Audience,

            ValidateLifetime = true,

            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_jwtSettings.SecretKey))
        };

        try
        {
            // Validates the token signature and claims.
            var handler = new JwtSecurityTokenHandler();

            var principal = handler.ValidateToken(
                token,
                validationParameters,
                out _);

            // Extract user information from JWT claims.
            return new AuthenticatedIdentity
            {
                Id = principal.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "",
                Name = principal.FindFirst(ClaimTypes.Name)?.Value ?? "",
                Role = principal.FindFirst(ClaimTypes.Role)?.Value ?? ""
            };
        }
        catch
        {
            // Invalid tokens should never continue through the pipeline.
            return null;
        }
    }
}