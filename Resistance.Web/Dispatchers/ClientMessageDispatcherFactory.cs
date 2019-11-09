using Microsoft.AspNetCore.SignalR;
using Resistance.Web.Hubs;
using Resistance.Web.Services;
using System;
using System.Threading.Tasks;

namespace Resistance.Web.Dispatchers
{
    public class ClientMessageDispatcherFactory : IClientMessageDispatcherFactory
    {
        private readonly IHubContext<GameHub, IGameHubClient> _gameHubContext;
        private readonly IGameConnectionIdStore _gameConnectionIdStore;

        public ClientMessageDispatcherFactory(
            IHubContext<GameHub, IGameHubClient> gameHubContext,
            IGameConnectionIdStore gameConnectionIdStore)
        {
            _gameHubContext = gameHubContext;
            _gameConnectionIdStore = gameConnectionIdStore;
        }

        public IClientMessageDispatcher CreateClientMessageDispatcher(Func<IGameHubClient, Task> clientMethod)
            => new ClientMessageDispatcher(_gameHubContext, _gameConnectionIdStore, clientMethod);
    }
}
