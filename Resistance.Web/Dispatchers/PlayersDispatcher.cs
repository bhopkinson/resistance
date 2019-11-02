using MediatR;
using Microsoft.AspNetCore.SignalR;
using Resistance.Web.Dispatchers.Models;
using Resistance.Web.Hubs;
using System.Threading;
using System.Threading.Tasks;

namespace Resistance.Web.Dispatchers
{
    public class PlayersDispatcher : INotificationHandler<PlayersListNotification>
    {
        private readonly IHubContext<GameHub, IGameHubClient> _gameHubContext;

        public PlayersDispatcher(IHubContext<GameHub, IGameHubClient> gameHubContext)
        {
            _gameHubContext = gameHubContext;
        }

        public async Task Handle(PlayersListNotification notification, CancellationToken cancellationToken)
        {
            await _gameHubContext.Clients.All.UpdatePlayersList(notification.Players);
        }
    }
}
