namespace AiSecurityGateway.Core.Models;

// Contains context information about an AI request.
public class AiRequestContext
{
    // The authenticated user behind the request.
    public required AuthenticatedIdentity User { get; set; }

    // The AI agent making the request.
    public required string AgentId { get; set; }

    // The application using the AI agent.
    public required string ApplicationId { get; set; }

    // The requested resource.
    public required string Resource { get; set; }

    // The requested action.
    public required string Action { get; set; }
}