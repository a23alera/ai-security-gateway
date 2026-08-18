using AiSecurityGateway.Core.Models;

namespace AiSecurityGateway.Core.Interfaces;

public interface ITokenValidator
{
    // Validates token and returns identity information if successful.
    AuthenticatedIdentity? Validate(string token);
}