using AiSecurityGateway.Core.Interfaces;
using AiSecurityGateway.Core.Models;

namespace AiSecurityGateway.Security.Authorization;

public class AiAuthorizationService
{
    private readonly PolicyEngine _policyEngine;
    private readonly IAuditLogger _auditLogger;

    public AiAuthorizationService(
        PolicyEngine policyEngine,
        IAuditLogger auditLogger)
    {
        _policyEngine = policyEngine;
        _auditLogger = auditLogger;
    }

    public bool Authorize(AiRequestContext context)
    {
        bool allowed = _policyEngine.Evaluate(context);

        var auditEvent = new AuditEvent
        {
            UserId = context.User.Id,
            AgentId = context.AgentId,
            ApplicationId = context.ApplicationId,
            Resource = context.Resource,
            Action = context.Action,
            Allowed = allowed,
            Timestamp = DateTime.UtcNow
        };

        _auditLogger.Log(auditEvent);

        return allowed;
    }
}