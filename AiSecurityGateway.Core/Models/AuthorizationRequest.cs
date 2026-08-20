namespace AiSecurityGateway.Core.Models;

public class AuthorizationRequest
{
    public required AuthenticatedIdentity Identity { get; set; }

    public required string AgentId { get; set; }

    public required string ApplicationId { get; set; }

    public required string Resource { get; set; }

    public required string Action { get; set; }
}