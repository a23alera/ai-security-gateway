using AiSecurityGateway.Core.Models;
using AiSecurityGateway.Security.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AiSecurityGateway.Api.Controllers;

// Tests AI authorization decisions.
[ApiController]
[Route("api/[controller]")]
public class AiAuthorizationController : ControllerBase
{
    private readonly AiAuthorizationService _authorizationService;

    public AiAuthorizationController(
        AiAuthorizationService authorizationService)
    {
        _authorizationService = authorizationService;
    }

    [HttpPost]
    public IActionResult Authorize()
    {
        var context = new AiRequestContext
        {
            User = new AuthenticatedIdentity
            {
                Id = "user-123",
                Name = "HR User",
                Role = "HR"
            },

            AgentId = "hr-assistant",
            ApplicationId = "company-copilot",
            Resource = "EmployeeSalaryData",
            Action = "Read"
        };

        var allowed = _authorizationService.Authorize(context);

        return Ok(new
        {
            Allowed = allowed
        });
    }
}