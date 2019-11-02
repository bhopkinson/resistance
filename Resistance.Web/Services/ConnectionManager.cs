using Resistance.Web.Hubs.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resistance.Web.Services
{
    public class ConnectionManager
    {
        private static readonly ConcurrentDictionary<GamePlayer, string> _gamePlayerToConnectionIds = new ConcurrentDictionary<GamePlayer, string>();

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
