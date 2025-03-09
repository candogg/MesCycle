using MesCycle.Web.Business.Implementations.Abstract;
using Microsoft.AspNetCore.SignalR;

namespace MesCycle.Web.Business.Hubs
{
    /// <summary>
    /// Author: Can DOĞU
    /// </summary>
    public class NotificationHub(AgentMessagingService agentMessagingService) : Hub
    {
        public override async Task OnConnectedAsync()
        {
            await Clients.Caller.SendAsync("ReceiveConnectionId", Context.ConnectionId);

            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            var disconnectedUser = await agentMessagingService.RemoveAgentAsync(Context.ConnectionId);

            await Clients.Others.SendAsync("UserDisconnected", disconnectedUser);

            await base.OnDisconnectedAsync(exception);
        }
    }
}
