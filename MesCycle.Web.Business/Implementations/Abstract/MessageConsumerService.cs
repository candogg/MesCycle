using MassTransit;
using MesCycle.Web.Business.Contracts;
using MesCycle.Web.Business.Hubs;
using MesCycle.Web.Business.Implementations.Base;
using MesCycle.Web.Business.Interfaces;
using MesCycle.Web.Shared.Extensions;
using Microsoft.AspNetCore.SignalR;

namespace MesCycle.Web.Business.Implementations.Abstract
{
    /// <summary>
    /// Author: Can DOĞU
    /// </summary>
    public class MessageConsumerService(IHubContext<NotificationHub> hubContext) : ServiceBase, IConsumer<IMessageContract>
    {
        public async Task Consume(ConsumeContext<IMessageContract> context)
        {
            try
            {
                var receivedMessage = context.Message.Text;

                if (receivedMessage == null || receivedMessage.IsNullOrEmpty()) return;

                var dMessage = receivedMessage.Deserialize<AgentMessageContract>();

                if (dMessage == default || dMessage.Message.IsNullOrEmpty()) return;

                var processedMessage = $"{dMessage.Message} - Processed [OK]";

                Console.WriteLine($"{receivedMessage}");

                var agentMessage = new AgentMessageContract
                {
                    ConnectionId = dMessage.ConnectionId,
                    Message = processedMessage
                };

                await SendMessageToAgentAsync(agentMessage);

                await Task.CompletedTask;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private async Task SendMessageToAgentAsync(AgentMessageContract message)
        {
            await hubContext.Clients.Client(message.ConnectionId).SendAsync("ReceiveNotification", message);
        }
    }
}
