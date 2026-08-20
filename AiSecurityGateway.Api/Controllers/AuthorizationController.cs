using AiSecurityGateway.Core.Models;
using AiSecurityGateway.Security.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AiSecurityGateway.Api.Controllers;

// Tests authorization decisions.
[ApiController]
[Route("api/[controller]")]
public class AuthorizationController : ControllerBase
{
    private readonly AuthorizationService _authorizationService;

    public AuthorizationController(AuthorizationService authorizationService)
    {
        _authorizationService = authorizationService;
    }

    [HttpPost]
    public IActionResult Authorize()
    {
        // Temporary identity used to test authorization rules.
        var identity = new AuthenticatedIdentity
        {
            Id = "user-123",
            Name = "Test User",
            Role = "HR"
        };

        var request = new AuthorizationRequest
        {
            Identity = identity,

            AgentId = "customer-support",

            ApplicationId = "company-copilot",

            Resource = "EmployeeSalaryData",

            Action = "Read"
        };

        // Check if the identity is allowed to access the resource.
        var allowed = _authorizationService.Authorize(request);

        return Ok(new
        {
            Allowed = allowed
        });
    }
}