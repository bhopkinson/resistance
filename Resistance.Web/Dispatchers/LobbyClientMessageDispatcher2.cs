using Microsoft.AspNetCore.SignalR;
using Resistance.Web.Dispatchers.DispatchModels;
using Resistance.Web.Hubs;
using System;
using System.Threading.Tasks;

namespace Resistance.Web.Dispatchers
{
    public class LobbyClientMessageDispatcher2 : IClientMessageDispatcher
    {
        private readonly IHubContext<LobbyHub, ILobbyHubClient> _lobbyHubContext;
        private readonly Func<ILobbyHubClient, Task> _clientMethod;

        public LobbyClientMessageDispatcher2(
           IHubContext<LobbyHub, ILobbyHubClient> lobbyHubContext,
           Func<ILobbyHubClient, Task> clientMethod)
        {
            _lobbyHubContext = lobbyHubContext;
            _clientMethod = clientMethod;
        }

        public Task Publish(Lobby lobby)
        {
            throw new NotImplementedException();
        }

        public async Task Send() =>
            await _clientMethod(_lobbyHubContext.Clients.All);

        public async Task SendToConnectionId(string connectionId) =>
            await _clientMethod(_lobbyHubContext.Clients.Client(connectionId));
    }
}
