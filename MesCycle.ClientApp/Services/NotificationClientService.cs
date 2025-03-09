using MesCycle.ClientApp.Contracts;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Threading.Tasks;

namespace MesCycle.ClientApp.Services
{
    /// <summary>
    /// Author: Can DOĞU
    /// </summary>
    public class NotificationClientService
    {
        private readonly Action<AgentMessageContract> messageCallback;
        private readonly Action<string> connectionIdReceivedCallback;
        private HubConnection connection;
        private readonly string url;

        public NotificationClientService(Action<AgentMessageContract> messageCallback, Action<string> connectionIdReceivedCallback)
        {
            url = "https://localhost:7249/notificationhub";

            this.messageCallback = messageCallback;
            this.connectionIdReceivedCallback = connectionIdReceivedCallback;
        }

        public async Task StartAsync()
        {
            if (connection != null)
            {
                await connection.StopAsync();
                await connection.DisposeAsync();
            }

            connection = new HubConnectionBuilder()
                .WithUrl(url)
                .WithAutomaticReconnect()
                .Build();

            connection.On<string>("ReceiveConnectionId", connectionId =>
            {
                connectionIdReceivedCallback?.Invoke(connectionId);
            });

            connection.On<AgentMessageContract>("ReceiveNotification", update =>
            {
                messageCallback?.Invoke(update);
            });

            connection.Closed += Connection_Closed;

            await connection.StartAsync();
        }

        private Task Connection_Closed(Exception arg)
        {
            return Task.CompletedTask;
        }

        public async Task StopAsync()
        {
            if (connection == null || connection.State == HubConnectionState.Disconnected) return;

            await connection.StopAsync();

            await connection.DisposeAsync();
        }
    }
}
