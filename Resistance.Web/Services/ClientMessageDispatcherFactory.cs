using Microsoft.AspNetCore.SignalR;
using Resistance.Web.Dispatchers;
using Resistance.Web.Hubs;
using System;
using System.Threading.Tasks;

namespace Resistance.Web.Services
{
    public class ClientMessageDispatcherFactory : IClientMessageDispatcherFactory
    {
        private readonly IHubContext<LobbyHub, ILobbyHubClient> _lobbyHubClient;
        private readonly IHubContext<GameHub, IGameHubClient> _gameHubContext;
        private readonly IGameConnectionIdStore _gameConnectionIdStore;

        public ClientMessageDispatcherFactory(
            IHubContext<LobbyHub, ILobbyHubClient> lobbyHubClient,
            IHubContext<GameHub, IGameHubClient> gameHubContext,
            IGameConnectionIdStore gameConnectionIdStore)
        {
            _lobbyHubClient = lobbyHubClient;
            _gameHubContext = gameHubContext;
            _gameConnectionIdStore = gameConnectionIdStore;
        }

        public LobbyClientMessageDispatcher CreateClientMessageDispatcher(Func<ILobbyHubClient, Task> clientMethod)
            => new LobbyClientMessageDispatcher(null, _lobbyHubClient, clientMethod);

        public ClientMessageDispatcher CreateClientMessageDispatcher(Func<IGameHubClient, Task> clientMethod)
            => new ClientMessageDispatcher(null);
    }
}
