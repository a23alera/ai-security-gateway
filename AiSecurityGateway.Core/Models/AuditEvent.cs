namespace AiSecurityGateway.Core.Models;

// Represents a security event that can be audited.
public class AuditEvent
{
    // Who requested the access.
    public required string UserId { get; set; }

    // Which AI agent performed the action.
    public required string AgentId { get; set; }

    // Which application is using the AI agent.
    public required string ApplicationId { get; set; }

    // The resource that was requested.
    public required string Resource { get; set; }

    // The requested operation.
    public required string Action { get; set; }

    // The authorization result.
    public required bool Allowed { get; set; }

    // When the event happened.
    public DateTime Timestamp { get; set; }
}