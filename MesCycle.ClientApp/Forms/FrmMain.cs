using MesCycle.ClientApp.Contracts;
using MesCycle.ClientApp.Extensions;
using MesCycle.ClientApp.Helpers.Derived;
using MesCycle.ClientApp.Items;
using MesCycle.ClientApp.Services;
using System;
using System.Collections.Concurrent;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace MesCycle.ClientApp.Forms
{
    /// <summary>
    /// Author: Can DOĞU
    /// </summary>
    public partial class FrmMain : Form
    {
        private readonly NotificationClientService notificationClient;
        private readonly string myUniqueId;
        private readonly ConcurrentQueue<AgentMessageContract> receivedMessageQueue;
        private readonly System.Windows.Forms.Timer queueTimer;

        private string myConnectionId;

        public FrmMain()
        {
            InitializeComponent();

            notificationClient = new NotificationClientService(MessageCallback, ConnectionIdReceivedCallback);
            myUniqueId = Guid.NewGuid().ToString();
            receivedMessageQueue = new ConcurrentQueue<AgentMessageContract>();
            queueTimer = new System.Windows.Forms.Timer
            {
                Interval = 500,
            };

            queueTimer.Tick += ProcessQueue;
        }

        private void ProcessQueue(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke((MethodInvoker)ProcessQueueInternal);
            }
            else
            {
                ProcessQueueInternal();
            }
        }

        private void ProcessQueueInternal()
        {
            queueTimer.Stop();

            while (receivedMessageQueue.TryDequeue(out var message))
            {
                if (message == null || message.Message.IsNullOrEmpty()) continue;

                LstReceived.Items.Insert(0, $"Received: {DateTime.Now:HH:mm:ss} - {message.Message}");
            }

            queueTimer.Start();
        }

        private void FrmMain_Load(object sender, System.EventArgs e)
        {
            StartSignalRClient();

            queueTimer.Start();
        }

        private async void StartSignalRClient()
        {
            try
            {
                await notificationClient.StartAsync();

                BtnReconnect.Visible = false;
            }
            catch
            {
                LblStatus.Text = "OFFLINE";
                LblStatus.ForeColor = Color.Red;

                BtnReconnect.Visible = true;
            }
        }

        private void MessageCallback(AgentMessageContract message)
        {
            receivedMessageQueue.Enqueue(message);
        }

        private async void ConnectionIdReceivedCallback(string connectionId)
        {
            myConnectionId = connectionId;

            var agentContract = new AgentContract
            {
                ConnectionId = connectionId,
                AgentUId = myUniqueId,
            };

            var result = await HttpHelper.GetInstance.PostAsync<AgentContract, AgentContract>(agentContract, "https://localhost:7249/api/Agent/SetOnline", CancellationToken.None);

            if (result != null)
            {
                Invoke((MethodInvoker)delegate
                {
                    LblStatus.Text = $"ONLINE [ConnectionId: {connectionId}]";
                    LblStatus.ForeColor = Color.Green;
                });
            }
            else
            {
                Invoke((MethodInvoker)delegate
                {
                    LblStatus.Text = "OFFLINE";
                    LblStatus.ForeColor = Color.Red;
                });
            }
        }

        private async void BtnSend_Click(object sender, EventArgs e)
        {
            var message = new AgentMessageContract
            {
                ConnectionId = myConnectionId,
                Message = $"Random_{Guid.NewGuid()}"
            };

            var result = await HttpHelper.GetInstance.PostAsync<ResponseItem, AgentMessageContract>(message, "https://localhost:7249/api/Agent/SendMessage", CancellationToken.None);

            if (result != null && result.IsOk)
            {
                LstSent.Items.Insert(0, $"Sent: {DateTime.Now:HH:mm:ss} - {message.Message}");
            }
        }

        private void BtnReconnect_Click(object sender, EventArgs e)
        {

        }
    }
}
