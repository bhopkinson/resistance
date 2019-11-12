using Microsoft.AspNetCore.SignalR;
using Resistance.Web.Hubs;
using Resistance.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resistance.Web.Services
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

        public async Task SendToPlayerInGame(string gameCode, string playerId) =>
            await SendToConnectionId(
                _gameConnectionIdStore.GetPlayerConnectionIdForGame(gameCode, playerId));

        public async Task SendToPlayersInGame(string gameCode, ICollection<string> playerIds) =>
            await SendToConnecionIds(playerIds
                .Select(playerId => _gameConnectionIdStore.GetPlayerConnectionIdForGame(gameCode, playerId))
                .ToArray());

        public async Task SendToAllGameClients(string gameCode) =>
            await SendToConnecionIds(
                _gameConnectionIdStore.GetConnectionIdsForGame(gameCode));

        public async Task SendToConnectionId(string connectionId) =>
            await _clientMethod(_gameHubContext.Clients.Client(connectionId));

        private async Task SendToConnecionIds(ICollection<string> connectionIds) =>
            await Task.WhenAll(
                connectionIds.Select(
                    connectionId => SendToConnectionId(connectionId)));
    }
}
