using Resistance.Web.Hubs.RequestModels;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Resistance.Web.Services
{
    public class GameConnectionIdStore : IGameConnectionIdStore
    {
        private readonly ConcurrentDictionary<string, ConcurrentDictionary<string, string>> _gameToPlayerToConnectionIds;
        private readonly ConcurrentDictionary<string, ConcurrentDictionary<string, object>> _gameToNonPlayerConnectionIds;

        public GameConnectionIdStore() => _gameToPlayerToConnectionIds = new ConcurrentDictionary<string, ConcurrentDictionary<string, string>>();

        public ICollection<string> GetConnectionIds(string gameCode) => GetPlayerToConnectionIds(gameCode).Values;

        public string GetConnectionId(string gameCode, string playerId)
        {
            var playerToConnectionIds = GetPlayerToConnectionIds(gameCode);
            if (playerToConnectionIds.TryGetValue(playerId, out var connectionId))
            {
                return connectionId;
            }

            throw new Exception($"ConnectionId {connectionId} not found for player ${playerId}.");
        }

        public void StoreConnectionId(string gameCode, string connectionId)
        {
            _gameToNonPlayerConnectionIds.AddOrUpdate(gameCode, new ConcurrentDictionary<string, object>(), (k, connectionIds) =>
            {
                if (connectionIds.TryAdd(connectionId, null))
                {
                    throw new Exception($"ConnectionId {connectionId} already stored in game ${gameCode}.");
                }

                return connectionIds;
            });
        }

        public void StoreConnectionId(string gameCode, string playerId, string connectionId)
        {
            _gameToPlayerToConnectionIds.AddOrUpdate(gameCode, new ConcurrentDictionary<string, string>(), (k, playerToConnectionIds) =>
              {
                  if (!playerToConnectionIds.TryAdd(playerId, connectionId))
                  {
                      throw new Exception($"ConnectionId {connectionId} already stored for ${playerId} in game ${gameCode}.");
                  }

                  return playerToConnectionIds;
              });
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
