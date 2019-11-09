using Microsoft.AspNetCore.SignalR;
using Resistance.Web.Dispatchers;
using Resistance.Web.Dispatchers.DispatchModels;
using Resistance.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resistance.Web.Hubs
{
    public class ClientMessageDispatcher : IClientMessageDispatcher
    {
        private readonly IHubContext<GameHub, IGameHubClient> _gameHubContext;
        private readonly IGameConnectionIdStore _gameConnectionIdStore;
        private readonly Func<IGameHubClient, Task> _clientMethod;

        public ClientMessageDispatcher(
           IHubContext<GameHub, IGameHubClient> gameHubContext,
           IGameConnectionIdStore gameConnectionIdStore,
           Func<IGameHubClient, Task> clientMethod)
        {
            _gameHubContext = gameHubContext;
            _gameConnectionIdStore = gameConnectionIdStore;
            _clientMethod = clientMethod;
        }

        public async Task SendToPlayerInGame(string gameCode, string playerId)
        {
            var connectionId = _gameConnectionIdStore.GetConnectionId(gameCode, playerId);
            await SendToConnectionId(connectionId);
        }

        public async Task SendToPlayersInGame(string gameCode, ICollection<string> playerIds)
        {
            var connectionIds = playerIds
                .Select(playerId => _gameConnectionIdStore.GetConnectionId(gameCode, playerId))
                .ToArray();

            await SendToConnecionIds(connectionIds);
        }

        public async Task SendToAllClientsForGame(string gameCode)
        {
            var connectionIds = _gameConnectionIdStore.GetConnectionIdsForGame(gameCode);
            await SendToConnecionIds(connectionIds);
        }

        private async Task SendToConnectionId(string connectionId)
            => await _clientMethod(_gameHubContext.Clients.Client(connectionId));

        private async Task SendToConnecionIds(ICollection<string> connectionIds)
            => await Task.WhenAll(connectionIds.Select(connectionId =>
            {
                return SendToConnectionId(connectionId);
            }));
    }
}
