using Resistance.Web.Hubs.RequestModels;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Resistance.Web.Services
{
    public class GameConnectionIdStore : IGameConnectionIdStore
    {
        private readonly ConcurrentDictionary<string, ConcurrentDictionary<string, string>> _gameToPlayerToConnectionIds;

        public GameConnectionIdStore() => _gameToPlayerToConnectionIds = new ConcurrentDictionary<string, ConcurrentDictionary<string, string>>();

        public ICollection<string> GetConnectionIds(string gameCode) => GetPlayerToConnectionIds(gameCode).Values;

        public string GetConnectionId(string gameCode, string playerId)
        {
            var playerToConnectionIds = GetPlayerToConnectionIds(gameCode);
            if (playerToConnectionIds.TryGetValue(playerId, out var connectionId))
            {
                return connectionId;
            }

            throw new Exception($"ConnectionId not found for player ${playerId}.");
        }

        public void StoreConnectionId(GamePlayer gamePlayer, string connectionId)
        {
            
            _gameToPlayerToConnectionIds.TryAdd(gamePlayer, connectionId);
        }

        private ConcurrentDictionary<string, string> GetPlayerToConnectionIds(string gameCode)
        {
            if (_gameToPlayerToConnectionIds.TryGetValue(gameCode, out var playerToConnectionIds))
            {
                return playerToConnectionIds;
            }

            throw new Exception($"ConnectionIds not found for game code {gameCode}.");
        }
    }
}
