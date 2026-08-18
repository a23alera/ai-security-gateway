using AiSecurityGateway.Core.Models;

namespace AiSecurityGateway.Security.Authorization;

// Handles authorization decisions using security policies.
public class AuthorizationService
{
    private readonly PolicyEngine _policyEngine;

    public AuthorizationService(PolicyEngine policyEngine)
    {
        _policyEngine = policyEngine;
    }

    // Checks if an identity is allowed to access a resource.
    public bool Authorize(AuthorizationRequest request)
    {
        return _policyEngine.Evaluate(request);
    }
}