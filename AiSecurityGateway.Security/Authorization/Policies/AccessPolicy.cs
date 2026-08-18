namespace AiSecurityGateway.Security.Authorization.Policies;

// Represents a rule that defines who can access a resource.
public class AccessPolicy
{
    // The resource this policy protects.
    public required string Resource { get; set; }

    // The action that is allowed on the resource.
    public required string Action { get; set; }

    // Roles that are allowed to perform the action.
    public required List<string> AllowedRoles { get; set; }
}