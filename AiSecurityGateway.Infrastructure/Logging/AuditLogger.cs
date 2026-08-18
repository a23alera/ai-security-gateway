using AiSecurityGateway.Core.Interfaces;
using AiSecurityGateway.Core.Models;

namespace AiSecurityGateway.Infrastructure.Logging;

public class AuditLogger : IAuditLogger
{
    public void Log(AuditEvent auditEvent)
    {
        Console.WriteLine(
            $"[{auditEvent.Timestamp}] " +
            $"User: {auditEvent.UserId}, " +
            $"Resource: {auditEvent.Resource}, " +
            $"Action: {auditEvent.Action}, " +
            $"Allowed: {auditEvent.Allowed}");
    }
}