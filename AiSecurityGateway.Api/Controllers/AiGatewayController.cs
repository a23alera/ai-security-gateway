using AiSecurityGateway.Core.Interfaces;
using AiSecurityGateway.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace AiSecurityGateway.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AiGatewayController : ControllerBase
{
    private readonly IAccessControlService _accessControlService;

    public AiGatewayController(IAccessControlService accessControlService)
    {
        _accessControlService = accessControlService;
    }

    [HttpPost]
    public IActionResult HandleRequest(AiGatewayRequest request)
    {
        var allowed = _accessControlService.IsAllowed(
            request.AgentId,
            request.Resource,
            request.Action
        );

        if (!allowed)
        {
            return StatusCode(403, new
            {
                message = "AI request denied",
                agent = request.AgentId,
                resource = request.Resource,
                action = request.Action
            });
        }

        return Ok(new
        {
            message = "AI request approved",
            agent = request.AgentId,
            resource = request.Resource,
            action = request.Action
        });
    }
}