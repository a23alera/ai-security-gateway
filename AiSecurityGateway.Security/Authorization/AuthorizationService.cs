using AiSecurityGateway.Core.Models;
using AiSecurityGateway.Core.Interfaces;

namespace AiSecurityGateway.Security.Authorization;

// Handles authorization decisions using security policies.
public class AuthorizationService
{
    private readonly PolicyEngine _policyEngine;
    private readonly IAuditLogger _auditLogger;

    public AuthorizationService(
        PolicyEngine policyEngine,
        IAuditLogger auditLogger)
    {
        _policyEngine = policyEngine;
        _auditLogger = auditLogger;
    }

    public bool Authorize(AuthorizationRequest request)
    {
        var allowed = _policyEngine.Evaluate(request);

        // Store the authorization decision for auditing.
        _auditLogger.Log(new AuditEvent
        {
            UserId = request.Identity.Id,
            Resource = request.Resource,
            Action = request.Action,
            Allowed = allowed,
            Timestamp = DateTime.UtcNow
        });

        return allowed;
    }
}