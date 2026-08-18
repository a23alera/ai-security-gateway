using AiSecurityGateway.Core.Interfaces;

namespace AiSecurityGateway.Core.Services;

public class AccessControlService : IAccessControlService
{
    public bool IsAllowed(string agentId, string resource, string action)
    {
        if (agentId == "hr-assistant" &&
            resource == "EmployeeSalaryData" &&
            action == "Read")
        {
            return true;
        }

        return false;
    }
}