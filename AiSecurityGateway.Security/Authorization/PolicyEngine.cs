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
        // Later these can come from database or configuration.
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
                },
                AllowedAgents = new List<string>
                {
                    "hr-assistant"
                }
            }
        };
    }

    // Evaluates normal authorization requests.
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

    // Evaluates AI requests with agent validation.
    public bool Evaluate(AiRequestContext context)
    {
        var policy = _policies.FirstOrDefault(p =>
            p.Resource == context.Resource &&
            p.Action == context.Action);

        if (policy == null)
        {
            return false;
        }

        // Check user role.
        if (!policy.AllowedRoles.Contains(context.User.Role))
        {
            return false;
        }

        // Check AI agent.
        if (policy.AllowedAgents.Count > 0 &&
            !policy.AllowedAgents.Contains(context.AgentId))
        {
            return false;
        }

        return true;
    }
}