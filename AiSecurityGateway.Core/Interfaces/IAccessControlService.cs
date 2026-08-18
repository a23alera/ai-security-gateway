namespace AiSecurityGateway.Core.Interfaces;

public interface IAccessControlService
{
    bool IsAllowed(string agentId, string resource, string action);
}