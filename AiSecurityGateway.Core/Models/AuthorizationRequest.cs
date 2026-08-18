namespace AiSecurityGateway.Core.Models;

// Represents an access request that needs authorization.
public class AuthorizationRequest
{
    // The authenticated user or AI agent requesting access.
    public required AuthenticatedIdentity Identity { get; set; }

    // The resource the requester wants to access.
    public required string Resource { get; set; }

    // The action the requester wants to perform.
    public required string Action { get; set; }
}