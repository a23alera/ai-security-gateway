using AiSecurityGateway.Core.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AiSecurityGateway.Security.Authentication;

// Generates JWT tokens for development and testing.
public class JwtTokenGenerator
{
    private readonly JwtSettings _jwtSettings;

    public JwtTokenGenerator(IOptions<JwtSettings> jwtSettings)
    {
        _jwtSettings = jwtSettings.Value;
    }

    // Creates a signed JWT token containing user identity information.
    public string GenerateToken(AuthenticatedIdentity identity)
    {
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, identity.Id),
            new Claim(JwtRegisteredClaimNames.Name, identity.Name),
            new Claim(ClaimTypes.Role, identity.Role)
        };

        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));

        var credentials = new SigningCredentials(
            key,
            SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            claims: claims,
            expires: DateTime.UtcNow.AddHours(1),
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler()
            .WriteToken(token);
    }
}