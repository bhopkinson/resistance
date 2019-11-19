using Microsoft.AspNetCore.SignalR;
using Resistance.Web.Hubs;
using System;
using System.Threading.Tasks;

namespace Resistance.Web.Dispatchers
{
    public class LobbyClientMessageDispatcher : IClientMessageDispatcher
    {
        private readonly IHubContext<LobbyHub, ILobbyHubClient> _lobbyHubContext;
        private readonly Func<ILobbyHubClient, Task> _clientMethod;

        public LobbyClientMessageDispatcher(
           IHubContext<LobbyHub, ILobbyHubClient> lobbyHubContext,
           Func<ILobbyHubClient, Task> clientMethod)
        {
            _lobbyHubContext = lobbyHubContext;
            _clientMethod = clientMethod;
        }

        public async Task Send() =>
            await _clientMethod(_lobbyHubContext.Clients.All);

        public async Task SendToConnectionId(string connectionId) =>
            await _clientMethod(_lobbyHubContext.Clients.Client(connectionId));
    }
}
