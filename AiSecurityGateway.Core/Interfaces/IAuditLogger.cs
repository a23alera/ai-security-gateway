using AiSecurityGateway.Core.Models;

namespace AiSecurityGateway.Core.Interfaces;

public interface IAuditLogger
{
    void Log(AuditEvent auditEvent);
}