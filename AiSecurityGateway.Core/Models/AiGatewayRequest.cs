namespace AiSecurityGateway.Core.Models;

// Represents an incoming request from an AI application.
public class AiGatewayRequest
{
    public required string AgentId { get; set; }

    public required string ApplicationId { get; set; }

    public required string Prompt { get; set; }

    public required string Resource { get; set; }

    public required string Action { get; set; }
}