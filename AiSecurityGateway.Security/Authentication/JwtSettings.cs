namespace AiSecurityGateway.Security.Authentication;

// Contains configuration settings used for JWT validation.
public class JwtSettings
{
    public string SecretKey { get; set; } = string.Empty;

    public string Issuer { get; set; } = string.Empty;

    public string Audience { get; set; } = string.Empty;
}