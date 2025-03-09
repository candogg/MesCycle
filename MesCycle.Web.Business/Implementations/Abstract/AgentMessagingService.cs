using MesCycle.Web.Business.Contracts;
using System.Collections.Concurrent;

namespace MesCycle.Web.Business.Implementations.Abstract
{
    /// <summary>
    /// Author: Can DOĞU
    /// </summary>
    public class AgentMessagingService
    {
        private readonly ConcurrentDictionary<string, AgentContract> activeAgents;

        public AgentMessagingService()
        {
            activeAgents = new ConcurrentDictionary<string, AgentContract>();
        }

        public async Task<AgentContract> AddAgentAsync(AgentContract AgentContract)
        {
            if (activeAgents.ContainsKey(AgentContract.ConnectionId))
            {
                activeAgents.TryRemove(AgentContract.ConnectionId, out _);
            }

            activeAgents.TryAdd(AgentContract.ConnectionId, AgentContract);

            return await Task.FromResult(AgentContract);
        }

        public async Task<List<AgentContract>> GetAgentsAsync(AgentContract AgentContract)
        {
            return await Task.FromResult(activeAgents.Select(x => x.Value).Where(a => a.ConnectionId != AgentContract.ConnectionId).ToList());
        }

        public async Task<AgentContract?> RemoveAgentAsync(string connectionId)
        {
            if (activeAgents.ContainsKey(connectionId))
            {
                activeAgents.TryRemove(connectionId, out var AgentContract);

                return await Task.FromResult(AgentContract);
            }

            return await Task.FromResult<AgentContract?>(null);
        }
    }
}
