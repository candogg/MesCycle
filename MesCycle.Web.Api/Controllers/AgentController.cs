using MesCycle.Web.Business.Contracts;
using MesCycle.Web.Business.Implementations.Abstract;
using MesCycle.Web.Business.Interfaces;
using MesCycle.Web.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace MesCycle.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgentController(AgentMessagingService agentMessageService, IMessagePublishService messagePublishService) : ControllerBase
    {
        [HttpPost("SetOnline")]
        public async Task<IActionResult> SetOnline(AgentContract message)
        {
            var response = await agentMessageService.AddAgentAsync(message);

            return Ok(response);
        }

        [HttpPost("SendMessage")]
        public async Task<IActionResult> SendNotification(AgentMessageContract message)
        {
            var result = await messagePublishService.Publish(message.Serialize());

            return Ok(result);
        }
    }
}
