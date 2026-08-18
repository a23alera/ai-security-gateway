namespace AiSecurityGateway.Core.Interfaces;

public interface ITokenValidator
{
    bool Validate(string token);
}