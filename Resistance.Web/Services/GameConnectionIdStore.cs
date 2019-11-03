using Resistance.Web.Hubs.RequestModels;
using System;
using System.Collections.Concurrent;

namespace Resistance.Web.Services
{
    public class GameConnectionIdStore : IGameConnectionIdStore
    {
        private readonly ConcurrentDictionary<GamePlayer, string> _gamePlayerToConnectionIds;

        public GameConnectionIdStore()
        {
            _gamePlayerToConnectionIds = new ConcurrentDictionary<GamePlayer, string>();
        }

        public string GetConnectionId(GamePlayer gamePlayer)
        {
            if (_gamePlayerToConnectionIds.TryGetValue(gamePlayer, out var connectionId))
            {
                return connectionId;
            }

            throw new Exception("ConnectionId not found for player.");
        }

        public void StoreConnectionId(GamePlayer gamePlayer, string connectionId)
        {
            _gamePlayerToConnectionIds.TryAdd(gamePlayer, connectionId);
        }
    }
}
