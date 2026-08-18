using AiSecurityGateway.Core.Models;

namespace AiSecurityGateway.Security.Authorization;

// Handles authorization decisions for AI requests.
public class AiAuthorizationService
{
    private readonly PolicyEngine _policyEngine;

    public AiAuthorizationService(PolicyEngine policyEngine)
    {
        _policyEngine = policyEngine;
    }

    public bool Authorize(AiRequestContext context)
    {
        return _policyEngine.Evaluate(context);
    }
}