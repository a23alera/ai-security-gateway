namespace AiSecurityGateway.Security.Authorization.Policies;

// Represents a rule that defines who and what can access a resource.
public class AccessPolicy
{
    // The resource this policy protects.
    public required string Resource { get; set; }

    // The action allowed on the resource.
    public required string Action { get; set; }

    // Roles allowed to access the resource.
    public required List<string> AllowedRoles { get; set; }

    // AI agents allowed to access the resource.
    public List<string> AllowedAgents { get; set; } = new();
}