using AiSecurityGateway.Core.Models;
using AiSecurityGateway.Security.Authorization.Policies;

namespace AiSecurityGateway.Security.Authorization;

// Evaluates access requests against security policies.
public class PolicyEngine
{
    private readonly List<AccessPolicy> _policies;

    public PolicyEngine()
    {
        // Temporary policies.
        // Later these can come from a database or configuration.
        _policies = new List<AccessPolicy>
        {
            new AccessPolicy
            {
                Resource = "EmployeeSalaryData",
                Action = "Read",
                AllowedRoles = new List<string>
                {
                    "HR",
                    "Admin"
                }
            }
        };
    }

    // Checks if the identity is allowed to perform the requested action.
    public bool Evaluate(AuthorizationRequest request)
    {
        var policy = _policies.FirstOrDefault(p =>
            p.Resource == request.Resource &&
            p.Action == request.Action);

        if (policy == null)
        {
            return false;
        }

        return policy.AllowedRoles.Contains(request.Identity.Role);
    }
}