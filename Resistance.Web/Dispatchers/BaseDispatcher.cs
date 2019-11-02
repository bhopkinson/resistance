using Microsoft.AspNetCore.SignalR;
using Resistance.Web.Dispatchers.Models;
using Resistance.Web.Hubs;
using Resistance.Web.Hubs.Models;
using Resistance.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resistance.Web.Dispatchers
{
    public abstract class BaseDispatcher
    {
        protected readonly IHubContext<GameHub, IGameHubClient> _gameHubContext;
        private readonly ConnectionManager _connectionManager;

        public BaseDispatcher(IHubContext<GameHub, IGameHubClient> gameHubContext, ConnectionManager connectionManger)
        {
            _gameHubContext = gameHubContext;
            _connectionManager = connectionManger;
        }

        public IEnumerable<string> GetConnectionIds(NotificationContext context)
        {
            foreach (var gamePlayer in context.RecipientPlayers)
            {
                yield return _connectionManager.GetConnectionId(gamePlayer);
            }
        }
    }
}
